using EmailWebServiceLibrary.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models
{
    public record EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Adress to is required")]
        public string From { get; set; }

        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Email schema name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email subject is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Email bdy is required")]
        public string Body { get; set; }
        public string ReplyTo { get; set; }
        public string ReplyToDisplayName { get; set; }
        public EmailFooterModel EmailFooter { get; set; }
        public List<EmailSchemaVariablesModel> EmailSchemaVariables { get; set; }
    }
}
