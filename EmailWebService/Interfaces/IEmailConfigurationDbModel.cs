using EmailWebService.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IEmailConfigurationDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string ProviderName { get; set; }
        [Required]
        string SMTP { get; set; }
        [Required]
        int Port { get; set; }
        [Required]
        string Login { get; set; }
        [Required]
        string Password { get; set; }

        ICollection<AppEmailServiceSettingsDbModel> AppEmailServiceSettings { get; set; }
    }
}
