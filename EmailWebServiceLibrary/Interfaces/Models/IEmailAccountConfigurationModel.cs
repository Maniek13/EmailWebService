using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailAccountConfigurationModel
    {
        int Id { get; init; }
        int ServiceId { get; init; }
        string SMTP { get; init; }
        int Port { get; init; }
        string Login { get; init; }
        string Password { get; init; }
        ServicesPermisionsDbModel AppPermision { get; init; }
    }
}
