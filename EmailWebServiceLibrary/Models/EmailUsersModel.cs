using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailUsersModel : IEmailUsersModel
    {
        public int Id { get; init; }
        public string UserListId { get; init; }
        public string Name { get; init; }
        public string EmailAdress { get; init; }
    }
}
