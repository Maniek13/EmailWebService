using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailSchemaDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int ServiceId { get; set; }

        [Required]
        string Name { get; set; }
        [Required]
        string Body { get; set; }
        [Required]
        string From { get; set; }
        [Required]
        string DisplayName { get; set; }
        [Required]
        string ReplyToDisplayName { get; set; }
        [Required]
        string ReplyTo { get; set; }
        [Required]
        string Subject { get; set; }

        ServicesPermisionsDbModel ServicePermision { get; set; }
        EmailFooterDbModel EmailFooter { get; set; }
        ICollection<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
    }
}
