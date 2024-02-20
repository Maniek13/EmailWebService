using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly record struct EmailUsersListModel : IEmailUsersListModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ServiceId { get; init; }
        public List<EmailUserModel> Users { get; init; }
    }
}
