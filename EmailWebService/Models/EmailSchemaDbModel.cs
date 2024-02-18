using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailSchemaDbModel : IEmailSchemaDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Body { get; set; }

        [Required]
        public string Variables { get; set; }
    }
}
