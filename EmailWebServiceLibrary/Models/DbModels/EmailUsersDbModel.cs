using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailUsersDbModel : IEmailUsersDbModel
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
