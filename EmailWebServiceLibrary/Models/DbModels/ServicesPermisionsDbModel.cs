using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record ServicesPermisionsDbModel : IServicesPermisionsDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public EmailAccountConfigurationDbModel EmailAccountConfiguration { get; set; }
        public EmailSchemaDbModel EmailSchema { get; set; }
        public EmailRecipientsListDbModel EmailRecipientList { get; set; }
        public ICollection<EmailRecipientDbModel> EmailRecipients { get; set; }
    }
}
