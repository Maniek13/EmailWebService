using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IAppEmailServiceSettingsDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        long IdentityCodesId { get; set; }
        [Required]
        long EmailConfigurationId { get; set; }
    }
}
