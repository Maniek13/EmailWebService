using EmailWebServiceLibrary.Interfaces.Models.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailRecipientsListModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int ServiceId { get; set; }
        ICollection<EmailListRecipientModel> Recipients { get; set; }
    }
}
