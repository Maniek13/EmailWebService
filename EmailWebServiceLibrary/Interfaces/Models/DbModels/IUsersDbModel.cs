using EmailWebServiceLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public interface IUsersDbModel
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string EmailAdress { get; set; }
        ICollection<EmailRecipientDbModel> EmailRecipients { get; set; }

    }
}
