using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public readonly record struct EmailAccountConfigurationModel : IEmailAccountConfigurationModel
    {
        public int Id { get; init; }
        public int ServiceId { get; init; }
        public string SMTP { get; init; }
        public int Port { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public ServicesPermisionsModel ServicePermision { get; init; }
    }
}
