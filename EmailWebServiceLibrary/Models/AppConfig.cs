using EmailWebServiceLibrary.Interfaces.Configuration;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace EmailWebServiceLibrary.Models
{
    public class AppConfig : IAppConfig
    {
        public static string ConnectionString { get; set; }
        public static string ConnectionStringRO { get; set; }
        public static string SigningKey { get; set; }
        public static RequestCulture DefaultCulture { get; set; } = new RequestCulture("pl");
        public static CultureInfo[] GetCultureInfos()
        {
            return new[]
            {
                 new CultureInfo("en-US"),
                 new CultureInfo("pl"),
            };
        }

        
    }
}
