using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppEmailServiceSettingsDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdentityCodesId {  get; set; }
        [Required]
        public int EmailConfigurationId { get; set; }
    }
}
