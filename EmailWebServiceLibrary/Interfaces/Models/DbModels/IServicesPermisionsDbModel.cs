using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IServicesPermisionsDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string ServiceName { get; set; }
        EmailAccountConfigurationDbModel EmailAccountConfiguration { get; set; }
        EmailSchemaDbModel EmailSchema { get; set; }
        EmailRecipientsListDbModel EmailRecipientList { get; set; }
        EmailRecipientDbModel EmailRecipient { get; set; }
    }
}
