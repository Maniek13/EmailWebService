using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public class AppConfig : IAppConfig
    {
        public static string ConnectionString { get; set; }
        public static string ConnectionStringRO { get; set; }
        public static string ServiceName { get; set; }
    }
}
