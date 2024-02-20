using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailRecipientsListModel
    {
        int Id { get; init; }
        string Name { get; init; }
        int ServiceId { get; init; }
        List<EmailRecipientModel> Recipients { get; init; }
    }
}
