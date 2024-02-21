using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public class EmailAccountConfigurationDbModel : IEmailAccountConfigurationDbModel
    {
        [Key]
        public int Id { get; set; }
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
        public ServicesPermisionsDbModel AppPermision { get; set; }
    }
}
