using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
	public static class Extensions
	{

		/// <summary>
		/// Gets an attribute on an enum field value
		/// </summary>
		/// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
		/// <param name="enumVal">The enum value</param>
		/// <returns>The attribute of type T that exists on the enum value</returns>
		/// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
		public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
		{
			var type = enumVal.GetType();
			var memInfo = type.GetMember(enumVal.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
			return (attributes.Length > 0) ? (T)attributes[0] : null;
		}
		public static String ToVisualString(this IEnumerable<Allele> alleles)
		{
			return String.Join("", alleles.Select(a => a.ToVisualString()));
		}

		public static String ToVisualString(this Allele allele)
		{
			switch (allele)
			{
				case Allele.DontCare:
					return "D";
				case Allele.Empty:
					return "_";
				case Allele.OccupiedAny:
					return "A";
				case Allele.OccupiedO:
					return "O";
				case Allele.OccupiedX:
					return "X";
				case Allele.Response:
					return "R";
			}

			return "_";
		}
	}
}
