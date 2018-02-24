using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Persistance;
using Arcesoft.TicTacToe.Evolution.WindowsApplication.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.Dialogs
{
    internal partial class DlgOpenRegion : Form
    {
        private IDataAccess DataAccess { get; set; }

        public DlgOpenRegion(IDataAccess dataAccess)
        {
            InitializeComponent();

            DataAccess = dataAccess;
        }

        private void DlgOpenRegion_Load(object sender, EventArgs e)
        {
            var results = DataAccess.SearchRegionsMostRecent();

            regionSearchResultBindingSource.DataSource = results;
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (textBoxSearch.Text.Length >=3))
            {
                var results = DataAccess.SearchRegionsByName(textBoxSearch.Text);

                regionSearchResultBindingSource.DataSource = results;
            }
        }

        public static IRegion TryOpenRegion(FactoryContainer factoryContainer)
        {
            using (var dlg = factoryContainer.GetInstance<DlgOpenRegion>())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }

            return null;
        }


    }
}
