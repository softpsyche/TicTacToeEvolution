using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    [Binding]
    internal class CommonSteps : Steps
    {
        [Given(@"I expect an exception to be thrown")]
        public void GivenIExpectAnExceptionToBeThrown()
        {
            ExpectingException = true;
        }


        [Given(@"I have a container")]
        public void GivenIHaveAContainer()
        {
            var container = new Container();
            container.Options.AllowOverridingRegistrations = true;

            new Arcesoft.TicTacToe.DependencyInjection.Binder().BindDependencies(container);
            new TicTacToe.Evolution.DependencyInjection.Binder().BindDependencies(container);


            //this locks the container so no tx for us...
            //container.Verify();

            Container = container;
        }

        [Given(@"I have a tictactoe factory")]
        public void GivenIHaveATictactoeFactory()
        {
            TicTacToeFactory = Container.GetInstance<ITicTacToeFactory>();
        }


        [Given(@"I start a new game")]
        [When(@"I start a new game")]
        public void GivenIStartANewGame()
        {
            Invoke(() => Game = TicTacToeFactory.NewGame());
        }

    }
}
