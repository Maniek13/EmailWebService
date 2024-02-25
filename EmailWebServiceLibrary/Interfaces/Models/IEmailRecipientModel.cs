namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailRecipientModel
    {
        int Id { get; init; }
        int RecipientsListId { get; init; }
        int RecipmentId { get; init; }
        string Name { get; init; }
        string EmailAdress { get; init; }

    }
}
