using EmailWebServiceLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceTests.Helpers
{
    public static class Helper
    {
        public static void SetConnectionStrings()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");
            var config = configuration.Build();

            AppConfig.ConnectionStringRO = config.GetSection("AppConfig").GetSection("ReadOnlyConnection").Value;
            AppConfig.ConnectionString = config.GetSection("AppConfig").GetSection("Connection").Value;
        }
    }
}
