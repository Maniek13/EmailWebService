using EmailWebServiceLibrarys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public class AppPermisionDbModel : IAppPermisionDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public EmailConfigurationDbModel EmailConfiguration { get; set; }
        public EmailSchemaDbModel EmailSchema { get; set; }
        public EmailUsersListDbModel EmailUsersLists { get; set; }
    }
}
