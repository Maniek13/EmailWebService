using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppPermisionDbModel : IAppPermisionDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdentityCodeId { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public IdentityCodeDbModel IdentityCode { get; set; }
    }
}
