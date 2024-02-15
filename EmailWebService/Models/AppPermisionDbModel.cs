using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppPermisionDbModel : IAppPermisionDbModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string IdentityCodeId { get; set; }
        [Required]
        public string ServiceName { get; set; }
    }
}
