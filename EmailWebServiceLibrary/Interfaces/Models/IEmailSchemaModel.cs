using EmailWebServiceLibrary.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaModel
    {
        int Id { get; set; }
        int ServiceId { get; set; }
        string From { get; set; }
        string DisplayName { get; set; }
        string ReplyToDisplayName { get; set; }
        string ReplyTo { get; set; }
        string Name { get; set; }
        string Body { get; set; }
        string Subject { get; set; }
        EmailFooterModel EmailFooter { get; set; }
        List<EmailSchemaVariablesModel> EmailSchemaVariables { get; set; }
    }
}
