using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailUsersListModel : IEmailUsersListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public List<EmailUsersModel> Users { get; set; }
    }
}
