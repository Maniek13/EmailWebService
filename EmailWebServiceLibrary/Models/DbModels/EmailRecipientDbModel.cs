using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailRecipientDbModel : IEmailRecipientDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RecipientListId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public EmailRecipientsListDbModel RecipientList { get; set; }
    }
}
