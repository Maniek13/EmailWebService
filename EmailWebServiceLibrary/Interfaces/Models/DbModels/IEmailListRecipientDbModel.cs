using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailListRecipientDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int RecipientListId { get; set; }
        [Required]
        int RecipientId { get; set; }
        EmailRecipientsListDbModel? RecipientList { get; set; }
        EmailRecipmentDbModel Recipment { get; set; }

    }
}
