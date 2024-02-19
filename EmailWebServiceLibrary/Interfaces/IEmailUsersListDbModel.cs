using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailUsersListDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        int ServiceId { get; set; }
        AppPermisionDbModel AppPermision { get; set; }
        ICollection<EmailUsersDbModel> Users { get; set; }
    }
}
