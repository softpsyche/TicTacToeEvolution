using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcesoft.TicTacToe.Evolution.Organisms;
using Arcesoft.TicTacToe.Evolution.Selection;

namespace Arcesoft.TicTacToe.Evolution.Reproduction.Strategies
{
    public class SexualBreeder : IBreeder
    {
        public IEnumerable<Individual> Breed(IEnumerable<FitnessScore> fitnessScores, IReproductionSettings settings)
        {
            throw new NotImplementedException();
        }
    }

    public class AsexualBreeder : IBreeder
    {
        public IEnumerable<Individual> Breed(IEnumerable<FitnessScore> fitnessScores, IReproductionSettings settings)
        {
            List<Individual> theTasteOfANewGeneration = new List<Individual>();
            
            foreach (var score in fitnessScores.OrderByDescending(a => a.Score))
            {
                var childrenToHave = Convert.ToInt32(Math.Round(score.PercentageOfAllScores * settings.MaximumPopulationSize));

                //we will always have at least on child, no matter how much of a loser we are. This is only if the population still needs
                //some headcount of course.
                if (childrenToHave == 0)
                {
                    childrenToHave = 1;
                }

                //A protection against a highly homogenous gene pool. 
                if (childrenToHave > settings.IndividualChildBearingLimit)
                {
                    childrenToHave = settings.IndividualChildBearingLimit;
                }

                //if we are at max, we must only have the right number of kids
                if (childrenToHave + theTasteOfANewGeneration.Count > settings.MaximumPopulationSize)
                {
                    childrenToHave = settings.MaximumPopulationSize - theTasteOfANewGeneration.Count;
                }

                //create the copies
                theTasteOfANewGeneration.AddRange(score.Individual.Copy(childrenToHave));

                if (theTasteOfANewGeneration.Count == settings.MaximumPopulationSize)
                {
                    //get out of dodge yo
                    break;
                }
            }
 
            return theTasteOfANewGeneration;
        }
    }
}
