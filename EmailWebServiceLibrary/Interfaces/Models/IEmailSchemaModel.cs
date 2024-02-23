using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaModel
    {
        int Id { get; init; }
        int ServiceId { get; set; }
        string From { get; init; }
        string DisplayName { get; init; }
        string ReplyToDisplayName { get; init; }
        string ReplyTo { get; init; }
        string Name { get; init; }
        string Body { get; set; }
        string Subject { get; init; }
        EmailFooterModel EmailFooter { get; set; }
        List<EmailSchemaVariablesModel> EmailSchemaVariables { get; set; }
    }
}
