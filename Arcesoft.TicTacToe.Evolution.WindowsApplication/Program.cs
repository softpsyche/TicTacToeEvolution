using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            var container = Bootstrap();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.GetInstance<FormMain>());
		}

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            new TicTacToe.DependencyInjection.Binder().BindDependencies(container);
            new Evolution.DependencyInjection.Binder().BindDependencies(container);
            new WindowsApplication.DependencyInjection.Binder().BindDependencies(container);

            // Optionally verify the container.
            container.Verify();

            return container;
        }
    }
}
