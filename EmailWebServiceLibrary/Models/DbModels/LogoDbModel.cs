using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record LogoDbModel : ILogoDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public byte[] FileByteArray { get; set; }
        public ICollection<EmailFooterDbModel> EmailFooter { get; set; }
    }
}
