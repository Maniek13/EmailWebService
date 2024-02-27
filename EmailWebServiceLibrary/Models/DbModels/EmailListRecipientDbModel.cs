using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailListRecipientDbModel : IEmailListRecipientDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RecipientListId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        public EmailRecipientsListDbModel RecipientList { get; set; }
        public EmailRecipientDbModel Recipient { get; set; }
    }
}
