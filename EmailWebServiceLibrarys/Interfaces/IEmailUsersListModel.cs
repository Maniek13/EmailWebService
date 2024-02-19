namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailUsersListModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int ServiceId { get; set; }
        List<IEmailUsersModel> Users { get; set; }
    }
}
