using EmailWebServiceLibrary.Interfaces.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailConfigurationDbModel : IEmailConfigurationDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string ReplyTo { get; set; }
        [Required]
        public string ReplyToDisplayName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public string SMTP { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public AppPermisionDbModel AppPermision { get; set; }
    }
}
