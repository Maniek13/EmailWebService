using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
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

        ICollection<EmailFooterDbModel> EmailFooter { get; set; }
    }
}
