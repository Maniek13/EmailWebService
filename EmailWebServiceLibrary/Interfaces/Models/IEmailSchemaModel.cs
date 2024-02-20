using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

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
        string Body { get; init; }
        string Subject { get; init; }
        EmailFooterModel EmailFooter { get; init; }
        List<EmailSchemaVariablesModel> EmailSchemaVariablesModel { get; init; }
    }
}
