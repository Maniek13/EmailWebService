using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.Models.Models
{
    public record EmailListRecipientModel : IEmailListRecipientModel
    {
        public int Id { get; set; }
        public int RecipientListId { get; set; }
        public int RecipientId { get; set; }

        public EmailRecipientModel Recipient { get; set; }
    }
}
