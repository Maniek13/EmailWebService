using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppPermisionDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdentityCodesId { get; set; }
        [Required]
        public string ServiceName { get; set; }
    }
}
