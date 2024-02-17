using EmailWebService.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IAppPermisionDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        long IdentityCodeId { get; set; }
        [Required]
        string ServiceName { get; set; }

        IdentityCodeDbModel IdentityCode { get; set; }
    }
}
