using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public record struct EmailAccountConfigurationModel : IEmailAccountConfigurationModel
    {
        public int Id { get; init; }
        public int ServiceId { get; init; }
        public string SMTP { get; init; }
        public int Port { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public ServicesPermisionsDbModel AppPermision { get; init; }
    }
}
