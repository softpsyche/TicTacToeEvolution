using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.Organisms
{
    internal static class AlleleExtensions
    {
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
    }
}
