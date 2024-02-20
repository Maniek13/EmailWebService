using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IServicesPermisionsDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string ServiceName { get; set; }
        EmailAccountConfigurationDbModel EmailAccountConfiguration { get; set; }
        EmailSchemaDbModel EmailSchema { get; set; }
        EmailUsersListDbModel EmailUsersLists { get; set; }
    }
}
