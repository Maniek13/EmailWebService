using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.Models
{
    public interface IEmailListRecipientModel
    {
        int Id { get; set; }
        int RecipientListId { get; set; }
        int RecipientId { get; set; }
        EmailRecipientModel Recipient { get; set; }

    }
}
