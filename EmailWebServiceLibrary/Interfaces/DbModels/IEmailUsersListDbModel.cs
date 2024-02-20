using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailUsersListDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        int ServiceId { get; set; }
        ServicesPermisionsDbModel AppPermision { get; set; }
        ICollection<EmailUsersDbModel> Users { get; set; }
    }
}
