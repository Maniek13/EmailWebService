using EmailWebServiceLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.Models.DbModels
{
    public class UserDbModel : IUsersDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public ICollection<EmailRecipientDbModel> EmailRecipients { get; set; }

    }
}
