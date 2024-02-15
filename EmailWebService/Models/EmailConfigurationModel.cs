using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public class EmailConfigurationModel : IEmailConfigurationModel
    {
        public long Id { get; set; }
        public string ProviderName { get; set; }
        public string SMTP { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
