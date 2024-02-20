using EmailWebServiceLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
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
