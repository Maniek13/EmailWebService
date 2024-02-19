using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailSchemaVariablesDbModel
    {

        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }

        [Required]
        string Value { get; set; }
        EmailSchemaDbModel? EmailSchema { get; set; }
    }
}
