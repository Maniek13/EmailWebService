using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class IdentityCodesDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AppName { get; set; }
        [Required]
        public string IdentityCode { get; set; }
    }
}
