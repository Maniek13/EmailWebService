using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly record struct EmailRecipientModel : IEmailRecipientModel
    {
        public int Id { get; init; }
        public int RecipientsListId { get; init; }
        public string Name { get; init; }
        public string EmailAdress { get; init; }
    }
}
