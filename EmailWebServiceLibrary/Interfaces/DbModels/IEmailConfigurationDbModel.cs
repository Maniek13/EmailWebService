using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailConfigurationDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        string From { get; set; }
        [Required]
        string ReplyTo { get; set; }
        [Required]
        string ReplyToDisplayName { get; set; }
        [Required]
        string DisplayName { get; set; }
        [Required]
        int ServiceId { get; set; }
        [Required]
        string SMTP { get; set; }
        [Required]
        int Port { get; set; }
        [Required]
        string Login { get; set; }
        [Required]
        string Password { get; set; }
        AppPermisionDbModel AppPermision { get; set; }
    }
}
