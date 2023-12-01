using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;

namespace Fish.Common
{
    public partial class AppConst
    {
        #region GET CONFIGURATION
        private static IConfiguration baseconfig;
        /// <summary>
        /// Get Application Settings Configuration File
        /// Please add appsettings.json to your client project (REST API, console, Web)
        /// </summary>
        public static IConfiguration BaseConfiguration
        {
            get
            {
                if (baseconfig == null)
                {
                    string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    //string jsonFile = String.Format("appsettings.{0}.json", env.ToLower());
                    string jsonFile = "appsettings.json";

                    IConfigurationBuilder configBuilder = new ConfigurationBuilder().
                                                              SetBasePath(Directory.GetCurrentDirectory()).
                                                              AddJsonFile(jsonFile);
                    baseconfig = configBuilder.Build();
                }

                return baseconfig;
            }
        }
        #endregion

        #region READ CONNECTION STRING
       
        public static string FISH_CONN_STRING
        {
            get
            {
                return GetConnectionString("FISH_CONN_STRING");
            }
        }
        #endregion

        #region Methods

        private static IConfiguration GetConfiguration(string section = "AppConfigs")
        {
            string path = BaseConfiguration.GetSection(section).GetSection("SourcePath").Value;
            string name = BaseConfiguration.GetSection(section).GetSection("SourceName").Value;
            string appConfPath = Path.Combine(Directory.GetCurrentDirectory(), path);

            IConfiguration config;
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(appConfPath).AddJsonFile(name);

            config = builder.Build();
            return config;
        }

        private static string GetConnectionString(string key)
        {
            string connectionString = string.Empty;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                IConfiguration config = GetConfiguration("ConnectionStrings");

                if (config != null)
                {
                    connectionString = config.GetConnectionString(key);
                }
            }

            return connectionString;
        }

        #endregion


       
    }
}
