using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IAppPermisionDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string ServiceName { get; set; }
        EmailConfigurationDbModel EmailConfiguration { get; set; }
        EmailSchemaDbModel EmailSchema { get; set; }
        EmailUsersListDbModel EmailUsersLists { get; set; }
    }
}
