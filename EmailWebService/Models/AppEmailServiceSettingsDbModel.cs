using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppEmailServiceSettingsDbModel : IAppEmailServiceSettingsDbModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long IdentityCodesId { get; set; }
        [Required]
        public long EmailConfigurationId { get; set; }
    }
}
