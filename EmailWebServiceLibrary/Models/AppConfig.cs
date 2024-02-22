using EmailWebServiceLibrary.Interfaces.Configuration;

namespace EmailWebServiceLibrary.Models
{
    public class AppConfig : IAppConfig
    {
        public static string ConnectionString { get; set; }
        public static string ConnectionStringRO { get; set; }
        public static string SigningKey { get; set; }
        public static bool IsAuthenticated { get; set; }
    }
}
