namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailRecipientModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string EmailAdress { get; set; }

    }
}
