using EmailWebServiceLibrary.Interfaces.Configuration;

namespace EmailWebServiceLibrarys.Models
{
    public class AppConfig : IAppConfig
    {
        public static string ConnectionString { get; set; }
        public static string ConnectionStringRO { get; set; }
    }
}
