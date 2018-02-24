using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcesoft.TicTacToe.Evolution.WindowsApplication.Assets
{
    public static class EmbeddedResources
    {
        public static List<PresetPopulationSetting> PresetPopulationSettings
        {
            get
            {
                return GetEmbeddedResourceFromJson<PresetPopulationSetting[]>($"{nameof(PresetPopulationSettings)}.json").ToList();
            }
        }

        private static T GetEmbeddedResourceFromJson<T>(string resourceName)
        {
            return JsonConvert.DeserializeObject<T>(GetEmbeddedResourceString(resourceName));
        }
        private static string GetEmbeddedResourceString(string resourceName)
        {
            var path =  $"{typeof(EmbeddedResources).FullName.Replace(typeof(EmbeddedResources).Name,string.Empty)}{resourceName}";

            using (Stream resourceStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            {
                if (resourceStream == null)
                    return null;

                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
