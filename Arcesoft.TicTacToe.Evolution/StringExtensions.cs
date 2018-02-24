using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    public static class StringExtensions
    {
        public static string ToLowerInvariantSafe(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;

            return str.ToLowerInvariant();
        }

        public static bool ContainsSafe(this string str,string value)
        {
            if (str == null) return false;

            return str.Contains(value);
        }
    }
}
