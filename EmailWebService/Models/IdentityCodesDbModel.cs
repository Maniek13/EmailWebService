using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class IdentityCodesDbModel : IIdentityCodesDbModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string AppName { get; set; }
        [Required]
        public string IdentityCode { get; set; }
    }
}
