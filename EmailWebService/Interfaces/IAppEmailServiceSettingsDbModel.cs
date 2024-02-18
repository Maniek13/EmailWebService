using EmailWebService.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IAppEmailServiceSettingsDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int IdentityCodeId { get; set; }
        [Required]
        int EmailConfigurationId { get; set; }

        IdentityCodeDbModel IdentityCode { get; set; }
        EmailConfigurationDbModel EmailConfiguration { get; set; }
    }
}
