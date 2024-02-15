using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IEmailConfigurationDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        string ProviderName { get; set; }
        [Required]
        string SMTP { get; set; }
        [Required]
        string Port { get; set; }
        [Required]
        string Login { get; set; }
        [Required]
        string Password { get; set; }

    }
}
