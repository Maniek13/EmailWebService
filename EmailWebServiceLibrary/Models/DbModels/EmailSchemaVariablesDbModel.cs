using EmailWebServiceLibrary.Interfaces.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailSchemaVariablesDbModel : IEmailSchemaVariablesDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
        public EmailSchemaDbModel? EmailSchema { get; set; }
    }
}
