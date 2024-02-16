using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailConfigurationDbModel : IEmailConfigurationDbModel
    {
        public int a = 0;
        [Key]
        public long Id { get; set; }
        [Required]
        public string ProviderName { get; set; }
        [Required]
        public string SMTP { get; set; }
        [Required]
        public string Port { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
