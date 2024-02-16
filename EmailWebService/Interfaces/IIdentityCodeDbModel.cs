using EmailWebService.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IIdentityCodeDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        string AppName { get; set; }
        [Required]
        string IdentityCode { get; set; }
        ICollection<AppPermisionDbModel> AppPermisions { get; set; }
        AppEmailServiceSettingsDbModel AppEmailServiceSettings { get; set; }
    }
}
