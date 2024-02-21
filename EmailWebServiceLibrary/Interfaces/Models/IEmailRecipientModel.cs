namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailRecipientModel
    {
        int Id { get; init; }
        int RecipientsListId { get; init; }
        int ServiceId { get; set; }
        string Name { get; init; }
        string EmailAdress { get; init; }

    }
}
