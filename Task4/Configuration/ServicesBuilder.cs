using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Task4.Utils;

namespace Task4.Configuration
{
    public static class ServicesBuilder
    {
        public static IConfiguration Configuration => SConfiguration.Value;
        private static readonly Lazy<IConfiguration> SConfiguration;

        static ServicesBuilder()
        {
            SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = DirectoryManager.GetResourceFolderPath();

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
