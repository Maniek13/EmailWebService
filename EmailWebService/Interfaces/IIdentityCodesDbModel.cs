using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IIdentityCodesDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        string AppName { get; set; }
        [Required]
        string IdentityCode { get; set; }
    }
}
