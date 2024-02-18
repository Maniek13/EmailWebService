using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IEmailLUsersListsDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string Type { get; set; }
        // like email, email, email
        [Required]
        string UsserList { get; set; }
    }
}
