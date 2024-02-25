using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailRecipientDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        int RecipientListId { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string EmailAdress { get; set; }
        EmailRecipientsListDbModel? RecipientList { get; set; }

    }
}
