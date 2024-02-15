using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailLUsersListsDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        // like email, email, email
        [Required]
        public string UsserList { get; set; }
    }
}
