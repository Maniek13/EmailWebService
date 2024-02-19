using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailSchemaDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int ServiceId { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        string Body { get; set; }

        AppPermisionDbModel AppPermision { get; set; }
        ICollection<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
    }
}
