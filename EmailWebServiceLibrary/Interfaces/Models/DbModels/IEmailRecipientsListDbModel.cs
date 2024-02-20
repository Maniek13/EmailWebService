using EmailWebServiceLibrary.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IEmailRecipientsListDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        int ServiceId { get; set; }
        ServicesPermisionsDbModel AppPermision { get; set; }
        ICollection<EmailRecipientsDbModel> Recipients { get; set; }
    }
}
