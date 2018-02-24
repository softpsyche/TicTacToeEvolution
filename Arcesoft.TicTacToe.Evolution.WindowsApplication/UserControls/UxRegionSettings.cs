using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcesoft.TicTacToe.Evolution.Environs;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.UserControls
{
    public partial class UxRegionSettings : UserControl
    {
        private RegionSettings _regionSettings;
        internal RegionSettings RegionSettings
        {
            get
            {
                return _regionSettings;
            }
            set
            {
                _regionSettings = value;
                bindingSourceRegionSettings.DataSource = _regionSettings;
            }
        }

        public UxRegionSettings()
        {
            InitializeComponent();
        }


    }
}
