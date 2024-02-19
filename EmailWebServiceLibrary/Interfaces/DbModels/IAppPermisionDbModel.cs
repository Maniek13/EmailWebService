using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
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
