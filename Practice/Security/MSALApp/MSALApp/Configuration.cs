using Microsoft.Extensions.Configuration;
using System.IO;

namespace MSALApp
{
    public class Configuration
    {
        // Singleton
        private Configuration() => _configBuilder = new ConfigurationBuilder()
                                                        .SetBasePath(Directory.GetCurrentDirectory())
                                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                        .Build();

        private static Configuration _configuration;
        private static IConfigurationRoot _configBuilder;

        public static Configuration Instance
        {
            get
            {
                if (_configuration == null)
                    _configuration = new Configuration();
                return _configuration;
            }
        }

        public string GetValue(string section, string key)
        {
            var value = _configBuilder?.GetSection(section)?.GetSection(key)?.Value ?? string.Empty;
            return value;
        }

        public string GetValue(string key)
        {
            var value = _configBuilder?.GetSection(key)?.Value ?? string.Empty;
            return value;
        }
    }
}
