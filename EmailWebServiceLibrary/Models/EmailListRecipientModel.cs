using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

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
