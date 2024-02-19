using EmailWebServiceLibrary.Interfaces.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailSchemaDbModel : IEmailSchemaDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Body { get; set; }
        public AppPermisionDbModel AppPermision { get; set; }
        public ICollection<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
    }
}
