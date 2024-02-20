using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaModel
    {
        int Id { get; init; }
        int ServiceId { get; init; }
        string From { get; init; }
        string DisplayName { get; init; }
        string ReplyToDisplayName { get; init; }
        string ReplyTo { get; init; }
        string Name { get; init; }
        string Body { get; set; }
        string Subject { get; init; }
        IFormFileCollection Atachments { get; set; }
        IEmailFooterModel EmailFooter { get; init; }
        List<IEmailSchemaVariablesModel> EmailSchemaVariables { get; init; }
    }
}
