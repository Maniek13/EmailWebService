namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailUsersModel
    {
        int Id { get; set; }
        string UserListId { get; set; }
        string Name { get; set; }
        string EmailAdress { get; set; }
    }
}
