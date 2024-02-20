using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailUsersListModel
    {
        int Id { get; init; }
        string Name { get; init; }
        int ServiceId { get; init; }
        List<EmailUsersModel> Users { get; init; }
    }
}
