using EmailWebServiceLibrary.Interfaces.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record AppPermisionDbModel : IAppPermisionDbModel
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
