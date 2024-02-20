namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailUsersModel
    {
        int Id { get; init; }
        string UserListId { get; init; }
        string Name { get; init; }
        string EmailAdress { get; init; }
    }
}
