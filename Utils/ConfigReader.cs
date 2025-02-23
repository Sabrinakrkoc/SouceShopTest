using Microsoft.Extensions.Configuration;
using System.IO;

namespace SauceDemoShop.Config
{
    public static class ConfigReader
    {
        private static IConfigurationRoot _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Resources/appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string GetBaseUrl() => _configuration["AppSettings:BaseUrl"];
    }
}
