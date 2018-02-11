using Arcesoft.TicTacToe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
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
		/// Controls what moves this gene is valid for
		/// </summary>
		public Turn Turn { get; private set; }

		private Allele[] Alleles { get; set; }
		public Move? Response => IndexOfFirstResponse();

        public Allele[] GetAlleles() => this.Alleles.ToArray();

        public Gene(Turn turn)
		{
			Turn = turn;
			Priority = 0;
			Alleles = new Allele[9];
		}
		public Gene(Turn turn, Int32 priority, Allele[] alleles)
		{
			Turn = turn;
			Priority = priority;
			Alleles = alleles.ToArray();
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

				if (IsMatchCharacter(character, Alleles[i]) == false)
					return false;
			}

			return true;
		}

		private Boolean IsMatchCharacter(Char character, Allele allele)
		{
			Boolean isMatch;

			switch (character)
			{
				case BoardConstants.SquareEmptyChar:
					isMatch =
						(allele == Allele.DontCare) ||
						(allele == Allele.Empty) ||
						(allele == Allele.Response);
					break;
				case BoardConstants.SquareXChar:
					isMatch =
						(allele == Allele.DontCare) ||
						(allele == Allele.OccupiedAny) ||
						(allele == Allele.OccupiedX);
					break;
				case BoardConstants.SquareOChar:
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

		private Move? IndexOfFirstResponse()
		{
			for (Int32 i = 0; i < Alleles.Length; i++)
			{
				if (Alleles[i] == Allele.Response)
				{
					return (Move)i;
				}
			}

			return null;
		}

		public override string ToString()
		{
            return base.ToString();
			//return String.Format("(M:{0}|P:{1}) - {2}", this.Move, this.Priority, this.Alleles.ToVisualString());
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
	}


}
