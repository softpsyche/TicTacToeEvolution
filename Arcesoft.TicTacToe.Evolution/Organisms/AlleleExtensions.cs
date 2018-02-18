using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    internal static class AlleleExtensions
    {
        public static Allele[] ToAlleles(this string str)
        {
            return str.Select(a => a.ToAllele()).ToArray();
        }
        public static Allele ToAllele(this string str)
        {
            return str.SingleOrDefault().ToAllele();
        }
        public static Allele ToAllele(this char character)
        {
            switch (character)
            {
                case AlleleConstants.DontCareChar:
                    return Allele.DontCare;
                case AlleleConstants.EmptyChar:
                    return Allele.Empty;
                case AlleleConstants.OccupiedAnyChar:
                    return Allele.OccupiedAny;
                case AlleleConstants.OccupiedOChar:
                    return Allele.OccupiedO;
                case AlleleConstants.OccupiedXChar:
                    return Allele.OccupiedX;
                case AlleleConstants.ResponseChar:
                    return Allele.Response;
                default:
                    throw new ArgumentOutOfRangeException(nameof(character));
            }
        }

        public static string ToAlleleString(this IEnumerable<Allele> alleles)
        {
            if (alleles == null) return string.Empty;

            return string.Join(string.Empty, alleles.Select(a => a.ToChar().ToString()));
        }

        public static char ToChar(this Allele allele)
        {
            switch (allele)
            {
                case Allele.DontCare:
                    return AlleleConstants.DontCareChar;
                case Allele.Empty:
                    return AlleleConstants.EmptyChar;
                case Allele.OccupiedAny:
                    return AlleleConstants.OccupiedAnyChar;
                case Allele.OccupiedO:
                    return AlleleConstants.OccupiedOChar;
                case Allele.OccupiedX:
                    return AlleleConstants.OccupiedXChar;
                case Allele.Response:
                    return AlleleConstants.ResponseChar;
                default:
                    throw new ArgumentOutOfRangeException(nameof(allele));
            }
        }
    }
}
