using EmailWebServiceLibrarys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailSchemaVariablesDbModel : IEmailSchemaVariablesDbModel
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
