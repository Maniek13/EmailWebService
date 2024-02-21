using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models.DbModels
{
    public record EmailRecipientsListDbModel : IEmailRecipientsListDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public ServicesPermisionsDbModel ServicePermision { get; set; }
        public ICollection<EmailRecipientDbModel> Recipients { get; set; }
    }
}
