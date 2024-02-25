using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailRecipmentDbModel : IEmailRecipmentDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public ICollection<EmailListRecipientDbModel> EmailRecipients { get; set; }

    }
}
