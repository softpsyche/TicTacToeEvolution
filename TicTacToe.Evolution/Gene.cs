using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Evolution
{
	/// <summary>
	/// Represents a single response strategy to a given board position.
	/// This class is immutable. Flyweight pattern?
	/// </summary>
	public class Gene : IComparable<Gene>, IComparable
	{
		public const Int32 MaximumPriority = 100;
		public const Int32 MaximumMoves = 9;

		/// <summary>
		/// Controls the priority of this gene when it is searched
		/// </summary>
		public Int32 Priority { get; private set; }

		/// <summary>
		/// Controls what move this gene is valid for
		/// </summary>
		public Int32 Move { get; private set; }


		/// <summary>
		/// A list of potential responses used by the gene
		/// </summary>
		private Allele[] Alleles { get; set; }


		public Int32? Response
		{
			get
			{
				return IndexOfFirstResponse();
			}
		}

		public Gene(Int32 move)
		{
			this.Move = move;
			this.Priority = 0;
			this.Alleles = new Allele[9];
		}
		public Gene(Int32 move, Int32 priority, Allele[] alleles)
		{
			this.Move = move;
			this.Priority = priority;
			this.Alleles = alleles.ToArray();
		}

		/// <summary>
		/// Returns true if the gene is a viable match for the given game.
		/// </summary>
		/// <param name="gene"></param>
		/// <param name="game"></param>
		/// <returns></returns>
		public Boolean IsMatch(String gameBoardString)
		{
			for (var i = 0; i < gameBoardString.Length; i++)
			{
				var character = gameBoardString[i];

				if (IsMatchCharacter(character, this.Alleles[i]) == false)
					return false;
			}

			return true;
		}

		public Allele[] GetAlleles()
		{
			return this.Alleles.ToArray();
		}

		private Boolean IsMatchCharacter(Char character, Allele allele)
		{
			Boolean isMatch;

			switch (character)
			{
				case Board.SquareEmptyChar:
					isMatch =
						(allele == Allele.DontCare) ||
						(allele == Allele.Empty) ||
						(allele == Allele.Response);
					break;
				case Board.SquareXChar:
					isMatch =
						(allele == Allele.DontCare) ||
						(allele == Allele.OccupiedAny) ||
						(allele == Allele.OccupiedX);
					break;
				case Board.SquareOChar:
					isMatch =
						(allele == Allele.DontCare) ||
						(allele == Allele.OccupiedAny) ||
						(allele == Allele.OccupiedO);
					break;
				default:
					throw new ArgumentException("Character supplied is not a valid board square state");
			}

			return isMatch;
		}
		private Int32? IndexOfFirstResponse()
		{
			for (Int32 i = 0; i < this.Alleles.Length; i++)
			{
				if (this.Alleles[i] == Allele.Response)
				{
					return i;
				}
			}

			return null;
		}

		public override string ToString()
		{
			return String.Format("(M:{0}|P:{1}) - {2}", this.Move, this.Priority, this.Alleles.ToVisualString());
		}
		#region IComparable
		public int CompareTo(Gene other)
		{
			if (other == null) return 1;

			return Priority.CompareTo(other.Priority);
		}
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			var typeItem = obj as Gene;
			if (typeItem != null)
			{
				return Priority.CompareTo(typeItem.Priority);
			}
			else
			{
				throw new ArgumentException("Invalid type specifed for obj in comparison");
			}
		}
		#endregion

		private Int32? _key;
		public Int32 Key
		{
			get
			{
				if (!_key.HasValue)
				{
					_key = BuildKey();
				}

				return _key.Value;
			}
		}
		private Int32 BuildKey()
		{
			return
				(int)Alleles[0] * 1 +
				(int)Alleles[1] * 10 +
				(int)Alleles[2] * 100 +
				(int)Alleles[3] * 1000 +
				(int)Alleles[5] * 10000 +
				(int)Alleles[6] * 100000 +
				(int)Alleles[7] * 1000000 +
				(int)Alleles[8] * 10000000 +
				(Response.HasValue? Response.Value: 9) *		100000000 +
				Move *			1000000000;
		}
	}

	[Flags]
	public enum Allele : int
	{
		DontCare = 0,
		Empty = 1,
		OccupiedAny = 2,
		OccupiedX = 3,
		OccupiedO = 4,
		Response = 5,
	}
}
