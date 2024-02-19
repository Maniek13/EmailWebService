using EmailWebServiceLibrarys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailSchemaDbModel : IEmailSchemaDbModel
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
