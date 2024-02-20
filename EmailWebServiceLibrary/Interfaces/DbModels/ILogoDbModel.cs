using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface ILogoDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int EmailFooterId { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string Type { get; set; }
        [Required]
        byte[] FileByteArray { get; set; }

        EmailFooterDbModel EmailFooter {  get; set; }
    }
}
