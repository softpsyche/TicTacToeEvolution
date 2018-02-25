using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication
{
    public class ApplicationSettings
    {
        public int ReportProgressIntervalInGenerations => ReadApplicationSetting<int>(nameof(ReportProgressIntervalInGenerations));

        public bool AutomaticSaveFrequencyInSecondsEnabled => SettingExists(nameof(AutomaticSaveFrequencyInSeconds));
        public int AutomaticSaveFrequencyInSeconds => ReadApplicationSetting<int>(nameof(AutomaticSaveFrequencyInSeconds));

        private T ReadApplicationSetting<T>(string appSettingName)
        {
            if (SettingExists(appSettingName))
            {
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[appSettingName], typeof(T));
            }

            throw new ConfigurationErrorsException($"Application setting '{appSettingName}' not found in applications configuration file.");
        }

        private bool SettingExists(string appSettingName) => ConfigurationManager.AppSettings.AllKeys.Any(a => a.Equals(appSettingName, StringComparison.InvariantCultureIgnoreCase));

    }
}
