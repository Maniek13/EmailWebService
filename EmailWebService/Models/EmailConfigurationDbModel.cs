using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailConfigurationDbModel
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string ProviderName { get; set; }
        [Required]
        public string SMTP {  get; set; }
        [Required]
        public string Port { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
  
    }
}
