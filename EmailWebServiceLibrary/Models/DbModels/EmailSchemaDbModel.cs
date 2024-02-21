using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailSchemaDbModel : IEmailSchemaDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string ReplyTo { get; set; }
        [Required]
        public string ReplyToDisplayName { get; set; }
        [Required]
        public string Body { get; set; }
        public ServicesPermisionsDbModel ServicePermision { get; set; }
        public EmailFooterDbModel EmailFooter { get; set; }
        public ICollection<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
    }
}
