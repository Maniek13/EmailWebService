using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IEmailSchemaDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }

        //like: tekst #ValueName# tekst
        [Required]
        string Body { get; set; }

        //variables like: Name : Value , Name : Value ,
        [Required]
        string Variables { get; set; }
    }
}
