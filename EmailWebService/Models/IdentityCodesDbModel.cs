using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class IdentityCodeDbModel : IIdentityCodeDbModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string AppName { get; set; }
        [Required]
        public string IdentityCode { get; set; }

        public ICollection<AppPermisionDbModel> AppPermisions { get; set; }
        public AppEmailServiceSettingsDbModel AppEmailServiceSettings { get; set; }
    }
}
