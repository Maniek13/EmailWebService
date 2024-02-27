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
        public static CultureInfo[] PromotedCultures {  get; set; }
        public static CultureInfo[] GetCultureInfoArray(string[] culturesArray)
        {
            List<CultureInfo> culturesInfoList= new();
            for (int i = 0; i < culturesArray.Length; i++)
            {
                culturesInfoList.Add(new CultureInfo(culturesArray[0]));
            }
            return culturesInfoList.ToArray();
        }

        
    }
}
