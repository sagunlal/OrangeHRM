using System.Configuration;

namespace OrangeHRM.Framwork.Core
{
    public class Datareader
    {
        private static readonly Configuration config;

        static Datareader()
        {
            // Specify relative or absolute path to your external App.config
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestSuite\App.config");
            string fullPath = Path.GetFullPath(configPath);


            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"App.config not found at: {fullPath}");

            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = fullPath
            };

            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        public static string Get(string key)
        {
            string value = config.AppSettings.Settings[key]?.Value;

            if (value == null)
                throw new KeyNotFoundException($"Key '{key}' not found in App.config");

            return value;
        }
    }
}
