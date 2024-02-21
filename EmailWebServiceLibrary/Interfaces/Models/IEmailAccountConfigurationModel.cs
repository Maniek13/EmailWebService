using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailAccountConfigurationModel
    {
        int Id { get; init; }
        int ServiceId { get; set; }
        string SMTP { get; init; }
        int Port { get; init; }
        string Login { get; init; }
        string Password { get; init; }
        ServicesPermisionsModel ServicePermision { get; init; }
    }
}
