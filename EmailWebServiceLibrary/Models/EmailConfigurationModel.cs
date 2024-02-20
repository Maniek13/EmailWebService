using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailConfigurationModel : IEmailConfigurationModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string ReplyTo { get; set; }
        public string ReplyToDisplayName { get; set; }
        public string DisplayName { get; set; }
        public int ServiceId { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
