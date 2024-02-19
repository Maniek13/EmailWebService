using EmailWebServiceLibrarys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailUsersDbModel : IEmailUsersDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserListId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public EmailUsersListDbModel? UsersList { get; set; }
    }
}
