using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaModel
    {
        int Id { get; init; }
        int ServiceId { get; init; }
        string From { get; init; }
        public string DisplayName { get; init; }
        string ReplyToDisplayName { get; set; }
        string ReplyTo { get; set; }
        string Name { get; init; }
        string Body { get; init; }
        public string Subject { get; init; }
        List<EmailSchemaVariablesModel> EmailSchemaVariablesModel { get; init; }
    }
}
