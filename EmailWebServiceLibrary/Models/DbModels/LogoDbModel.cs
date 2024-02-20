using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public record LogoDbModel : ILogoDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmailFooterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string FileByteArray { get; set; }
        public EmailFooterDbModel EmailFooter { get; set; }
    }
}
