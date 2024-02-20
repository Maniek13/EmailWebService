using EmailWebServiceLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailFooterDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int EmailSchemaId { get; set; }
        [Required]
        string TextHtml { get; set; }
        EmailSchemaDbModel EmailSchema{ get; set;}
        LogoDbModel Logo { get; set; }
    }
}
