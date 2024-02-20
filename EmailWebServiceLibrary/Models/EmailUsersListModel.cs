using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailUsersListModel : IEmailUsersListModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ServiceId { get; init; }
        public List<EmailUsersModel> Users { get; init; }
    }
}
