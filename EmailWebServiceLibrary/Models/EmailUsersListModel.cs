using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailUsersListModel : IEmailUsersListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public List<IEmailUsersModel> Users { get; set; }
    }
}
