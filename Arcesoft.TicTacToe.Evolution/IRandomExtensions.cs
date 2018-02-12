using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution
{
    public static class IRandomExtensions
    {

        public static List<int> RandomNonRepeating(this IRandom random, int maxValueExclusive, int count)
        {
            if (count > maxValueExclusive)
            {
                throw new ArgumentException("count must be greater than min value", nameof(maxValueExclusive));
            }

            var randomNumbers = new List<int>();
            //if we have more numbers to pick than to leave out, its more efficient to REMOVE the numbers we dont want..
            if (count > maxValueExclusive / 2)
            {
                var totalItemsToRemove = maxValueExclusive - count;
                for (int i = 0; i < maxValueExclusive; i++)
                {
                    randomNumbers.Add(i);
                }

                while (totalItemsToRemove > 0)
                {
                    var newRandom = random.Next(randomNumbers.Count);
                    randomNumbers.RemoveAt(newRandom);

                    totalItemsToRemove--;
                }
            }
            else
            {//we have fewer, lets do this
                while (randomNumbers.Count < count)
                {
                    var newRandom = random.Next(maxValueExclusive);

                    if (!randomNumbers.Contains(newRandom))
                    {
                        randomNumbers.Add(newRandom);
                    }
                }
            }

            return randomNumbers;
        }
    }
}
