using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IAppPermisionDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        string IdentityCodeId { get; set; }
        [Required]
        string ServiceName { get; set; }
    }
}
