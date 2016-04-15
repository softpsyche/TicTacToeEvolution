/********************************************************************/
/*  Copyright ARRIS Enterprises, Inc. 2014 All rights reserved      */
/********************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WAOnline.Core.Common.Constants;
using WAOnline.Core.Common.Equipment;
using WAOnline.Core.Common.Message;
using WAOnline.Partner.Plugins.Billing.CSG.Entities;
using WAOnline.Partner.Plugins.Billing.CSG.Utils;
using WAOnline.Partner.Plugins.Framework.Exceptions;
using WAOnline.Partner.Plugins.Framework.Utils;
using WAOnline.Partner.SDK.Entities;
using WAOnline.Partner.SDK.Entities.Workorder;

namespace WAOnline.Partner.Plugins.Billing.CSG.Processes
{
	/// <summary>
	/// Equipment Change Process
	/// </summary>
	public class EquipmentChangeProcess
	{
		#region Constants

		/// <summary>
		/// Y value
		/// </summary>
		private const string YValue = "Y";

		/// <summary>
		/// N value
		/// </summary>
		private const string NValue = "N";

		/// <summary>
		/// Equip owner as purchased
		/// </summary>
		private const string EQUIPOWNER_PURCHASED = "P";

		/// <summary>
		/// Equip owner as rented
		/// </summary>
		private const string EQUIPOWNER_RENTED = "R";

		/// <summary>
		/// CHG Function
		/// </summary>
		private const string CHGFunction = "CHG";

		/// <summary>
		/// NEW Function
		/// </summary>
		private const string NEWFunction = "NEW";

		/// <summary>
		/// Outlet Number
		/// </summary>
		private const string OutletNum = "OutletNum";

		/// <summary>
		/// Original Outlet Number
		/// </summary>
		private const string OriginalOutletNum = "OriginalOutletNum";

		/// <summary>
		/// Equipment model
		/// </summary>
		private const string EquipModel = "EquipModel";

		/// <summary>
		/// Equip ID Required
		/// </summary>
		private const string EquipIdRequired = "EquipIDRequired";

		/// <summary>
		/// EquipmentPlaceHolder
		/// </summary>
		private const string EquipmentPlaceHolder = "*";


		private const string No = "0";

		#endregion

		#region Attributes

		/// <summary>
		/// CsgMessageGenerator instance
		/// </summary>
		readonly CsgMessageGenerator messageGenerator = new CsgMessageGenerator();

		/// <summary>
		/// Csg work order plugin configuration instance
		/// </summary>
		CsgOutboundWorkOrderPluginConfiguration pluginConfiguration = new CsgOutboundWorkOrderPluginConfiguration();

		/// <summary>
		/// Current use of equipments
		/// </summary>
		Dictionary<int, Equipment> currentEquipments = new Dictionary<int, Equipment>();

		/// <summary>
		/// New use of equipments
		/// </summary>
		Dictionary<int, Equipment> newEquipments = new Dictionary<int, Equipment>();

		/// <summary>
		/// Plugin master data
		/// </summary>
		WorkOrderPartnerMasterData pluginMasterData;

		/// <summary>
		/// Max value between outlets
		/// </summary>
		int maxOutlets = 0;

		#endregion

		#region Methods

		/// <summary>
		/// Method to emit Equipment change
		/// </summary>
		/// <param name="job"></param>
		/// <param name="pluginConfiguration"></param>
		/// <returns></returns>
		public OutgoingMessage EmitEquipment(PartnerJob job, CsgOutboundWorkOrderPluginConfiguration configuration, WorkOrderPartnerMasterData masterData,
			WorkOrderStandardMasterData standardMasterData, ref IDictionary<string, string> requiredService, string jobId)
		{
			LogUtils.Debug(string.Format(LoggingMessageConstants.StartProcess, LoggingMessageConstants.EmitEquipment, job.JobId));

			pluginConfiguration = configuration;
			pluginMasterData = masterData;
			
			OutgoingMessage outgoingMessage = new OutgoingMessage();
			Msg transactionMessage = null;
			if (job.Customer == null || string.IsNullOrEmpty(job.Customer.AccountNumber))
			{
				throw new CsgWorkOrderPluginException(string.Format(CultureInfo.CurrentCulture, ErrorMessageConstants.NoAccountId));
			}

			if (!AreThereEquipmentChanges(job))
			{
				return outgoingMessage;
			}

			string returnLocation = string.Empty;

			if (job.WorkerId != null)
			{
				FsrIdMapping fsrIdMappingRow = masterData.FsrIdMapping.Where(x => x.WorkerId == job.WorkerId).FirstOrDefault();
				if (fsrIdMappingRow != null)
				{
					returnLocation = fsrIdMappingRow.FsrId;
				}
			}

			if (string.IsNullOrEmpty(returnLocation))
			{
				returnLocation = pluginConfiguration.ReturnLocationCode;
			}

			int lastEquipmentOutlet = 0;

			for (int i = 1; i <= maxOutlets; i++)
			{
				if (newEquipments.ContainsKey(i))
				{
					Equipment newEquipment = newEquipments[i];

					if (!string.IsNullOrEmpty(newEquipment.SerialNumber) && newEquipment.SerialNumber != EquipmentPlaceHolder)
					{
						lastEquipmentOutlet = i;
					}
				}
			}

			List<Equipment> equipments = CreateEquipmentChangesList(lastEquipmentOutlet, ref requiredService);


			transactionMessage = FillUpdateOrderDetailTransaction(Job.GetSMSFlags(job), jobId, returnLocation, equipments);

			outgoingMessage.Message = XMLUtils.ObjectToXml(transactionMessage);

			if (job.WorkerId != null)
			{
				outgoingMessage.ReturnTag = job.WorkerId.ToString();
			}
			return outgoingMessage;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Method to emit equipment change
		/// </summary>
		/// <param name="currentEquipment"></param>
		/// <param name="newEquipment"></param>
		/// <param name="requestedFunction"></param>
		/// <param name="index"></param>
		private Equipment EmitEquipmentChange(ref IDictionary<string, string> requiredService, Equipment currentEquipment, Equipment newEquipment, string requestedFunction, int index)
		{
			string outlet = CsgWorkOrderPluginHelper.ConvertOutletNumberToLetter(index.ToString());

			Equipment equipment = new Equipment();
			equipment.Outlet = outlet;
			equipment.RequestedFunction = requestedFunction;

			switch (requestedFunction)
			{
				case NEWFunction:

					equipment.SerialNumber = newEquipment.SerialNumber;

					if (!string.IsNullOrEmpty(newEquipment.SerialNumber) && newEquipment.SerialNumber == EquipmentPlaceHolder)
					{
						equipment.Type = string.IsNullOrEmpty(newEquipment.Type) ? NValue : newEquipment.Type;
						equipment.Ownership = EQUIPOWNER_PURCHASED;
						StringBuilder builder = new StringBuilder();
						builder.Append(EquipmentPlaceHolder);
						builder.Append(outlet.PadLeft(4));
						equipment.HandshakeId = builder.ToString();
					}
					else
					{
						equipment.Type = newEquipment.Type;
						equipment.Ownership = string.IsNullOrEmpty(newEquipment.Ownership) ? null : newEquipment.Ownership;
						equipment.Model = newEquipment.Model;

						CheckRequiredService(equipment.Type, outlet, ref requiredService);
					}

					break;

				case CHGFunction:

					equipment.SerialNumber = currentEquipment.SerialNumber;

					if (string.IsNullOrEmpty(newEquipment.SerialNumber))
					{
						equipment.NewSerialNumber = string.Empty.PadLeft(25);
					}
					else
					{
						if (newEquipment.SerialNumber == EquipmentPlaceHolder)
						{
							equipment.NewSerialNumber = string.IsNullOrEmpty(newEquipment.SerialNumber) ? EquipmentPlaceHolder : newEquipment.SerialNumber;
							equipment.NewOutlet = outlet;
							equipment.NewType = NValue;
							equipment.Ownership = EQUIPOWNER_PURCHASED;
						}
						else
						{
							equipment.NewSerialNumber = newEquipment.SerialNumber;
							equipment.NewOutlet = outlet;
							equipment.NewType = newEquipment.Type;
							equipment.Ownership = string.IsNullOrEmpty(newEquipment.Ownership) ? null : newEquipment.Ownership;
							equipment.Model = newEquipment.Model;

							CheckRequiredService(equipment.NewType, outlet, ref requiredService);
						}
					}

					break;
			}

			return equipment;
		}

		/// <summary>
		/// Check if there is any required service for the equipment
		/// </summary>
		/// <param name="equipment"></param>
		/// <param name="requiredService"></param>
		/// <returns></returns>
		private void CheckRequiredService(string type, string outlet, ref IDictionary<string, string> requiredService)
		{
			if (requiredService.Count() > 0)
			{
				requiredService.Remove(string.Empty);

				List<ACPEquipmentService> acpEquipmentServices = pluginMasterData.ACPEquipmentService;

				if (!requiredService.ContainsKey(CsgWorkOrderPluginHelper.ConvertOutletNumber(outlet).ToString()))
				{
					ACPEquipmentService acpEquipmentService = acpEquipmentServices.FirstOrDefault(x => x.EquipmentType.Equals(type));

					if (acpEquipmentService != null)
					{
						requiredService.Add(CsgWorkOrderPluginHelper.ConvertOutletNumber(outlet).ToString(), acpEquipmentService.ServiceCode);
					}
				}
			}
		}

		/// <summary>
		/// Creates a list of equipments' changes
		/// </summary>
		/// <param name="job"></param>
		/// <returns></returns>
		private bool AreThereEquipmentChanges(PartnerJob job)
		{
			SetOutletNumToAddedEquipment(job.JobEquipments);

			maxOutlets = FindMaxOutletNumber(job.JobEquipments);

			foreach (PartnerJobEquipment partnerEquipment in job.JobEquipments)
			{
				CreateEquipmentMap(partnerEquipment);
			}

			for (int i = 1; i <= maxOutlets; i++)
			{
				Equipment currentEquipment = currentEquipments.ContainsKey(i) ? currentEquipments[i] : null;
				Equipment newEquipment = newEquipments.ContainsKey(i) ? newEquipments[i] : null;

				if (!AreEquipmentsEqual(currentEquipment, newEquipment))
				{
					return true;
				}
			}

			return false;
		}

		private void SetOutletNumToAddedEquipment(IList<PartnerJobEquipment> jobEquipments)
		{
//			Add:
//- Use original outlet number as well as outlet number to find the max
//- MaxOutletNumber is used from two places and will need different filter i.e. when finding outlet number of add pending / error use filter else no filter needed
//Merge:
//- Respect plugin generated outlet number. Plugin generated equipment has Original State is either # or N
//Swap / Delete
//- CurEquip use OriginalOutlet Number and include existing equipment in cur and new list
//we have original outlet and outlet number in extension data.
//csg order rules for outlets:
//Equipment order
//----------------
//- Primary (exsiting or pending add)
//- Secondary existing
//- secondary pending add
//- to delete


			// set outletnum of swap equipment
			var addedEquipmentList =
				jobEquipments.Where(je => je.Status == StatusTypes.AddedPending || je.Status == StatusTypes.AddedError).ToList();

			var swapAddedEquipmentList =
				addedEquipmentList.Where(
					je =>
						je.JobEquipmentDatas.FirstOrDefault(
							e => e.Name == "PreviousJobEquipmentId" && string.IsNullOrEmpty(e.Value) == false) != null).ToList();

			foreach (var curEquip in swapAddedEquipmentList)
			{
				var previousJobEquipmentId = curEquip.JobEquipmentDatas.First(ce => ce.Name == "PreviousJobEquipmentId").Value;
				var prevEquip = jobEquipments.FirstOrDefault(e => e.JobEquipmentId.ToString() == previousJobEquipmentId);
				if (prevEquip != null)
				{
					var prevOutletExtEntry = prevEquip.JobEquipmentDatas.FirstOrDefault(e => e.Name == OutletNum);
					if (prevOutletExtEntry == null)
					{
						throw new CsgWorkOrderPluginException(string.Format(CultureInfo.CurrentCulture, "Outlet extension entry not found for existing equipment!!"));
					}

					SetOutletNumber(curEquip, prevOutletExtEntry.Value);
				}
			}

			int maxOutletNum = FindLastUsedOutletNumber(jobEquipments);

			// set outletnum of newly added technician equipment
			var newTechnicianAddedEquipmentList =
				addedEquipmentList.Where(
					je => !IsAddedPredictiveEquipment(je.JobEquipmentDatas) && !IsSwappedAddedEquipment(je.JobEquipmentDatas)).ToList();

			foreach (var curEquip in newTechnicianAddedEquipmentList)
			{
				SetOutletNumber(curEquip, (++maxOutletNum).ToString());
			}
		}

		private Boolean IsAddedPredictiveEquipment(IEnumerable<PartnerExtensionField> partnerExtensionFields)
		{
			return HasExtensionData(partnerExtensionFields, "OriginalState");		
		}
		private Boolean IsSwappedAddedEquipment(IEnumerable<PartnerExtensionField> partnerExtensionFields)
		{
			return HasExtensionData(partnerExtensionFields, "PreviousJobEquipmentId");
		}
		private Boolean HasExtensionData(IEnumerable<PartnerExtensionField> partnerExtensionFields, String name)
		{
			if (partnerExtensionFields == null)
				return false;

			return partnerExtensionFields.Any(a => a.Name == name && !String.IsNullOrEmpty(a.Value));
		}



		private int FindLastUsedOutletNumber(IList<PartnerJobEquipment> jobEquipments)
		{
			var localJobEquipments = jobEquipments.Where(a => IsCountableStatusForOutletNumber(a)).ToList();

			int maxOutletNum = 0;
			foreach (var curEquip in localJobEquipments)
			{
				int outletNumberToUse = 0;

				if (HasExtensionData(curEquip.JobEquipmentDatas, OriginalOutletNum))
				{
					outletNumberToUse = GetExtensionDataInteger(curEquip.JobEquipmentDatas, OriginalOutletNum);
				}
				else
				{
					outletNumberToUse = GetExtensionDataInteger(curEquip.JobEquipmentDatas, OutletNum);
				}

				maxOutletNum = Math.Max(maxOutletNum, outletNumberToUse);
			}

			return maxOutletNum;
		}
		private int FindMaxOutletNumber(IList<PartnerJobEquipment> jobEquipments)
		{
			int maxOutletNum = 0;
			foreach (var curEquip in jobEquipments)
			{
				var currentOutletNumber = GetExtensionDataInteger(curEquip.JobEquipmentDatas, OutletNum);
				var originalOutletNumber = GetExtensionDataInteger(curEquip.JobEquipmentDatas, OriginalOutletNum);

				maxOutletNum = (new[] { maxOutletNum, currentOutletNumber, originalOutletNumber }).Max();
			}

			return maxOutletNum;
		}
		private int GetExtensionDataInteger(IEnumerable<PartnerExtensionField> partnerExtensionFields,String name)
		{
			if (partnerExtensionFields != null)
			{
				var foundItem = partnerExtensionFields.FirstOrDefault(a => a.Name == name);

				if (foundItem != null)
				{
					return Int32.Parse(foundItem.Value);
				}
			}

			return 0;
		}

		private Boolean IsCountableStatusForOutletNumber(PartnerJobEquipment partnerJobEquipment)
		{
			StatusTypes statusTypes = partnerJobEquipment.Status;

			//Made this explicit so adding new enums doesnt 'magically' assume a behavior. 
			//I think an exception is preferable to an assumption which leads to a hard to find bug later on. 
			switch (statusTypes)
			{
				case StatusTypes.Added:
				case StatusTypes.RemovedPending:
				case StatusTypes.RemovedError:
				case StatusTypes.Existing:
					return true;
				case StatusTypes.Removed:
					return false;
				case StatusTypes.AddedError:
				case StatusTypes.AddedPending:
					//more refined logic....
					return IsAddedPredictiveEquipment(partnerJobEquipment.JobEquipmentDatas);
				case StatusTypes.None:
					throw new InvalidOperationException("Should not have a None status");
				default:
					throw new Exception("Unable to determine whether the statusType '{0}' should be countable or not. Please configure this status type (i.e. make a code change to the function that threw this exception)");
			}
		}
		

		private void SetOutletNumber(PartnerJobEquipment jobEquipment, string outletNumber)
		{
			SetStringExtensionData(jobEquipment.JobEquipmentDatas, OutletNum, outletNumber);
			SetStringExtensionData(jobEquipment.JobEquipmentDatas, OriginalOutletNum, outletNumber);
		}

		private void SetStringExtensionData(IList<PartnerExtensionField> extensionFieldList, String name, String value)
		{
			var extensionField = extensionFieldList.FirstOrDefault(e => e.Name == name);
			if (extensionField == null) // add extension entry
				extensionFieldList.Add(new PartnerExtensionField
				{
					Name = name,
					Type = "1",
					Value = value
				});
			else // edit extension entry
				extensionField.Value = value;
		}

		/// <summary>
		/// Method to initialize equipment
		/// </summary>
		/// <param name="partnerEquipment"></param>
		/// <returns></returns>
		private void CreateEquipmentMap(PartnerJobEquipment partnerEquipment)
		{
			string serialNumber;

			PartnerExtensionField extensionField = null;

			int outletNum = GetExtensionDataInteger(partnerEquipment.JobEquipmentDatas, OutletNum);
			int originalOutletNum = GetExtensionDataInteger(partnerEquipment.JobEquipmentDatas, OriginalOutletNum);


			PartnerExtensionField typeResponse =
				partnerEquipment.Equipment.EquipmentType.EquipmentTypeDatas.FirstOrDefault(x => x.Name.Equals(EquipIdRequired));

				string serialNumberRequired = string.Empty;

				if (typeResponse != null)
				{
					serialNumberRequired = typeResponse.Value;
				}

			if (serialNumberRequired == No)
				serialNumber = EquipmentPlaceHolder;
			else
				serialNumber = partnerEquipment.Equipment.SerialNumber.Trim().ToUpper();


			string ownership = null;
			string model = null;

			if (serialNumber.Equals(EquipmentPlaceHolder))
			{
				ownership = EQUIPOWNER_PURCHASED;
			}
			else
			{
				ownership = (partnerEquipment.Ownership == JobEquipmentOwnership.Rented ? EQUIPOWNER_RENTED : EQUIPOWNER_PURCHASED);

				if (string.IsNullOrEmpty(ownership))
				{
					ownership = pluginConfiguration.OwnershipCode;
				}
				if (!string.IsNullOrEmpty(ownership) && ownership.Equals(EQUIPOWNER_PURCHASED))
				{
					extensionField = partnerEquipment.JobEquipmentDatas.FirstOrDefault(x => x.Name.Equals(EquipModel));
					if (extensionField != null)
					{
						model = extensionField.Value.Trim();
					}
				}
			}

			Equipment equipment = new Equipment();
			equipment.SerialNumber = partnerEquipment.Equipment.SerialNumber;
			equipment.Type = partnerEquipment.Equipment.EquipmentType != null ? partnerEquipment.Equipment.EquipmentType.Name : null;
			equipment.Ownership = string.IsNullOrEmpty(ownership) ? null : ownership;
			equipment.Model = model;

			if ((partnerEquipment.Status == StatusTypes.AddedPending || partnerEquipment.Status == StatusTypes.AddedError || partnerEquipment.Status == StatusTypes.Existing) && !newEquipments.ContainsKey(outletNum))
			{
				newEquipments.Add(outletNum, equipment);
			}

			if ((partnerEquipment.Status == StatusTypes.RemovedPending || partnerEquipment.Status == StatusTypes.RemovedError || partnerEquipment.Status == StatusTypes.Existing) && !currentEquipments.ContainsKey(originalOutletNum))
			{
				currentEquipments.Add(originalOutletNum, equipment);
			}
		}

		/// <summary>
		/// Method to create the list of equipment changes
		/// </summary>
		/// <param name="lastEquipmentOutlet"></param>
		/// <returns></returns>
		private List<Equipment> CreateEquipmentChangesList(int lastEquipmentOutlet, ref IDictionary<string, string> requiredService)
		{
			List<Equipment> equipments = new List<Equipment>();
			Equipment currentPlaceHolder = new Equipment { SerialNumber = EquipmentPlaceHolder, Type = NValue };
			Equipment newPlaceHolder = new Equipment();

			for (int i = 1; i <= maxOutlets; i++)
			{
				Equipment currentEquipment = currentEquipments.ContainsKey(i) ? currentEquipments[i] : null;
				Equipment newEquipment = newEquipments.ContainsKey(i) ? newEquipments[i] : null;

				if (!AreEquipmentsEqual(currentEquipment, newEquipment))
				{
					if (currentEquipment == null)
					{
						//this is an add
						equipments.Add(EmitEquipmentChange(ref requiredService, null, newEquipment, NEWFunction, i));
					}
					else
					{
						if (newEquipment == null)
						{
							if (i > lastEquipmentOutlet)
							{
								//this is a removal
								equipments.Add(EmitEquipmentChange(ref requiredService, currentEquipment, newPlaceHolder, CHGFunction, i));
							}
							else
							{
								if (!currentEquipment.SerialNumber.Equals(EquipmentPlaceHolder))
								{
									//this is a remove but we have to use a placeholder to avoid a gap (must be contiguous outlet numbers for CSG)
									equipments.Add(EmitEquipmentChange(ref requiredService, currentEquipment, currentPlaceHolder, CHGFunction, i));
								}
							}
						}
						else
						{
							//this is a SWAP
							equipments.Add(EmitEquipmentChange(ref requiredService, currentEquipment, newEquipment, CHGFunction, i));
						}
					}
				}
			}

			return equipments;
		}

		/// <summary>
		/// Compare two equipments and returns true if they are equal
		/// </summary>
		/// <param name="currentEquipment"></param>
		/// <param name="newEquipment"></param>
		/// <returns></returns>
		private bool AreEquipmentsEqual(Equipment currentEquipment, Equipment newEquipment)
		{
			if (currentEquipment == null && newEquipment == null)
			{
				return true;
			}
			if ((currentEquipment == null && newEquipment != null) || (currentEquipment != null && newEquipment == null))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.SerialNumber, newEquipment.SerialNumber))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.HandshakeId, newEquipment.HandshakeId))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.Type, newEquipment.Type))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.Outlet, newEquipment.Outlet))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.Model, newEquipment.Model))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.NewSerialNumber, newEquipment.NewSerialNumber))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.NewType, newEquipment.NewType))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.NewOutlet, newEquipment.NewOutlet))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.Ownership, newEquipment.Ownership))
			{
				return false;
			}
			if (!ReferenceEquals(currentEquipment.RequestedFunction, newEquipment.RequestedFunction))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Method to fill the UpdateOrderDetail transaction
		/// </summary>
		/// <param name="flags"></param>
		/// <param name="jobId"></param>
		/// <param name="returnLocation"></param>
		/// <param name="equipments"></param>
		/// <returns></returns>
		public Msg FillUpdateOrderDetailTransaction(string flags, string jobId, string returnLocation, List<Equipment> equipments)
		{
			Msg transactionMessage = messageGenerator.CreateMessage(pluginConfiguration, TransactionType.UpdateOrderDetail, flags);
			transactionMessage.body.UpdateOrderDetail.Order.OrderId = jobId.Substring(0, 16);
			transactionMessage.body.UpdateOrderDetail.Order.ProcessProvisionableItems = YValue;
			transactionMessage.body.UpdateOrderDetail.EquipmentList = new EquipmentList();
			transactionMessage.body.UpdateOrderDetail.EquipmentList.ReturnStatus =
				pluginConfiguration.ReturnStatusCode != null ? pluginConfiguration.ReturnStatusCode : string.Empty;
			transactionMessage.body.UpdateOrderDetail.EquipmentList.ReturnLocation =
				returnLocation != null ? returnLocation : string.Empty;
			if (equipments != null)
			{
				transactionMessage.body.UpdateOrderDetail.EquipmentList.Equipment = equipments.ToArray();
			}

			//If we have no jobs then we should not send an empty list. CSG will reject
			//the transaction if an empty list is passed in the XML message. This statement
			//will cause the xml parser to not emit the tag for JobList which is what we want.
			if (transactionMessage.body.UpdateOrderDetail.JobList.Any() == false)
			{
				transactionMessage.body.UpdateOrderDetail.JobList = null;
			}

			return transactionMessage;
		}

		#endregion
	}