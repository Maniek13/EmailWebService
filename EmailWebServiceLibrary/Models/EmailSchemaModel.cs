using EmailWebServiceLibrary.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Models
{
    public record EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string From { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ReplyTo { get; set; }
        public string ReplyToDisplayName { get; set; }
        public EmailFooterModel EmailFooter { get; set; }
        public List<EmailSchemaVariablesModel> EmailSchemaVariables { get; set; }
    }
}
