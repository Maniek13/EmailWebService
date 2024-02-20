using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailUsersDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string UserListId { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string EmailAdress { get; set; }
        EmailUsersListDbModel? UsersList { get; set; }
    }
}
