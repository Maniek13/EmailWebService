using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailUsersListModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int ServiceId { get; set; }
        List<EmailUsersModel> Users { get; set; }
    }
}
