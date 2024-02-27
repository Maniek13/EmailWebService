using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailRecipientModel : IEmailRecipientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAdress { get; set; }
    }
}
