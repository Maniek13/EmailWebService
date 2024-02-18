using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppEmailServiceSettingsDbModel : IAppEmailServiceSettingsDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdentityCodeId { get; set; }
        [Required]
        public int EmailConfigurationId { get; set; }
        public IdentityCodeDbModel IdentityCode { get; set; }
        public EmailConfigurationDbModel EmailConfiguration { get; set; }
    }
}
