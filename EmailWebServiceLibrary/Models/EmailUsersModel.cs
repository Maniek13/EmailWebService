using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailUsersModel : IEmailUsersModel
    {
        public int Id { get; set; }
        public string UserListId { get; set; }
        public string Name { get; set; }
        public string EmailAdress { get; set; }
    }
}
