using EmailWebServiceLibrarys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailUsersListDbModel : IEmailUsersListDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public AppPermisionDbModel AppPermision { get; set; }
        public ICollection<EmailUsersDbModel> Users { get; set; }
    }
}
