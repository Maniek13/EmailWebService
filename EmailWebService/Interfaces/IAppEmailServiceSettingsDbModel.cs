using EmailWebService.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IAppEmailServiceSettingsDbModel
    {
        [Key]
        long Id { get; set; }
        [Required]
        long IdentityCodeId { get; set; }
        [Required]
        long EmailConfigurationId { get; set; }

        IdentityCodeDbModel IdentityCode { get; set; }
        EmailConfigurationDbModel EmailConfiguration { get; set; }
    }
}
