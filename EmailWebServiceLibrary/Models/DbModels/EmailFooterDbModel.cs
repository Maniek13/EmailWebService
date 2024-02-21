using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailFooterDbModel : IEmailFooterDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmailSchemaId { get; set; }
        [Required]
        public string TextHtml { get; set; }
        public EmailSchemaDbModel EmailSchema { get; set; }
        public LogoDbModel Logo { get; set; }
    }
}
