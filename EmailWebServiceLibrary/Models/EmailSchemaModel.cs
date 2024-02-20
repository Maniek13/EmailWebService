using EmailWebServiceLibrary.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; init; }
        public int ServiceId { get; init; }
        public string From { get; init; }
        public string DisplayName { get; init; }
        public string Name { get; init; }
        public string Subject { get; init; }
        public string Body { get; init; }
        public string ReplyTo { get; init; }
        public string ReplyToDisplayName { get; init; }
        public EmailFooterModel EmailFooter { get; init; }
        public List<EmailSchemaVariablesModel> EmailSchemaVariablesModel { get; init; }
    }
}
