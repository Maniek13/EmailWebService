using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Interfaces
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
