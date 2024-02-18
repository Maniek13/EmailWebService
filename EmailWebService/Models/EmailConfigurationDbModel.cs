using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailConfigurationDbModel : IEmailConfigurationDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProviderName { get; set; }
        [Required]
        public string SMTP { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<AppEmailServiceSettingsDbModel> AppEmailServiceSettings { get; set; }
    }
}
