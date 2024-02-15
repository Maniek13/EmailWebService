using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailSchemaDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //like: tekst #ValueName# tekst
        [Required]
        public string Body { get; set; }

        //variables like: Name : Value , Name Value ,
        [Required]
        public string Variables { get; set; }
    }
}
