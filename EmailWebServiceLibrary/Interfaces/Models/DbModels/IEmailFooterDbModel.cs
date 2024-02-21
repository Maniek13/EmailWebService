using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailFooterDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int EmailSchemaId { get; set; }
        [Required]
        string TextHtml { get; set; }
        EmailSchemaDbModel EmailSchema { get; set; }
        LogoDbModel Logo { get; set; }
    }
}
