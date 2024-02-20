using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly record struct EmailRecipientsListModel : IEmailRecipientsListModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ServiceId { get; init; }
        public List<EmailRecipientModel> Recipients { get; init; }
    }
}
