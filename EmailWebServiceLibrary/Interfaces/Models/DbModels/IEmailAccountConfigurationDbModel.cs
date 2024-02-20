using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailAccountConfigurationDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int ServiceId { get; set; }
        [Required]
        string SMTP { get; set; }
        [Required]
        int Port { get; set; }
        [Required]
        string Login { get; set; }
        [Required]
        string Password { get; set; }
        ServicesPermisionsDbModel AppPermision { get; set; }
    }
}
