using Arcesoft.TicTacToe.ArtificialIntelligence.Strategies;
using Arcesoft.TicTacToe.DependencyInjection;
using Arcesoft.TicTacToe.Entities;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.GameImplementation
{
    internal class TicTacToeFactory : ITicTacToeFactory
    {
        private FactoryContainer FactoryContainer { get; set; }

        public TicTacToeFactory(FactoryContainer factoryContainer)
        {
            FactoryContainer = factoryContainer;
        }

        public IDatabaseBuilder NewDatabaseBuilder()
        {
            return FactoryContainer.GetInstance<IDatabaseBuilder>();
        }

        public IGame NewGame()
        {
            return FactoryContainer.GetInstance<IGame>();
        }

        public IGame NewGame(IEnumerable<Move> moves)
        {
            var game = NewGame();

            foreach (var move in moves)
            {
                if (game.IsMoveValid(move))
                {
                    game.Move(move);
                }
                else
                {
                    throw new GameException("Invalid move passed in. Cannot create game from moves.");
                }
            }

            return game;
        }

        public IArtificialIntelligence NewArtificialIntelligence(string type)
        {
            switch (type)
            {
                case ArtificialIntelligenceTypes.BruteForce:
                    return FactoryContainer.GetInstance<BruteForce>();
                case ArtificialIntelligenceTypes.OmniscientGod:
                    return FactoryContainer.GetInstance<OmniscientGod>();
                case ArtificialIntelligenceTypes.LightningGod:
                    return FactoryContainer.GetInstance<LightningGod>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), $"Unable to create AI for type '{type}'. No implementation found for this type.");
            }
        }
    }
}
