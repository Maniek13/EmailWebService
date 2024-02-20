namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailUserModel
    {
        int Id { get; init; }
        string UserListId { get; init; }
        string Name { get; init; }
        string EmailAdress { get; init; }
    }
}
