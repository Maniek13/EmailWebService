using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailAccountConfigurationModel : IEmailAccountConfigurationModel
    {
        public int Id { get; init; }
        public int ServiceId { get; set; }
        public string SMTP { get; init; }
        public int Port { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public ServicesPermisionsModel ServicePermision { get; init; }
    }
}
