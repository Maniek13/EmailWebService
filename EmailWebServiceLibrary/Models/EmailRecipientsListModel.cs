using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Interfaces.Models.Models;
using System.Collections;

namespace EmailWebServiceLibrary.Models
{
    public record EmailRecipientsListModel : IEmailRecipientsListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public ICollection<EmailListRecipientModel> Recipients { get; set; }
    }
}
