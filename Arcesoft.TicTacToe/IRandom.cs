using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe
{
	public interface IRandom
	{
		/// <summary>Returns a nonnegative random number less than the specified maximum.</summary>
		/// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero.</param>
		/// <returns>
		///     A 32-bit signed integer greater than or equal to zero, and less than maxValue;
		///     that is, the range of return values ordinarily includes zero but not maxValue.
		///     However, if maxValue equals zero, maxValue is returned.
		/// </returns>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		Int32 Next(Int32 maxValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        Int32 Next(Int32 minValue, Int32 maxValue);

        /// <summary>
        ///     Returns a random floating-point number that is greater than or equal to 0.0,
        ///     and less than 1.0.
        /// </summary>
        /// <returns>
        ///  A double-precision floating point number that is greater than or equal to 0.0,
        ///  and less than 1.0.
        /// </returns>
        double NextDouble();
	}
}
