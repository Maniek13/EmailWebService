using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Models
{
    public record struct EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; init; }
        public int ServiceId { get; init; }
        public string From { get; init; }
        public string DisplayName { get; init; }
        public string Name { get; init; }
        public string Subject { get; init; }
        public string Body { get; set; }
        public string ReplyTo { get; init; }
        public string ReplyToDisplayName { get; init; }

        public IFormFileCollection Atachments { get; set; }
        public IEmailFooterModel EmailFooter { get; init; }
        public List<IEmailSchemaVariablesModel> EmailSchemaVariables { get; init; }
    }
}
