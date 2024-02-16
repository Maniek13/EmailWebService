using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppEmailServiceSettingsDbModel : IAppEmailServiceSettingsDbModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long IdentityCodeId { get; set; }
        [Required]
        public long EmailConfigurationId { get; set; }
        public IdentityCodeDbModel IdentityCode { get; set; }
        public EmailConfigurationDbModel EmailConfiguration { get; set; }
    }
}
