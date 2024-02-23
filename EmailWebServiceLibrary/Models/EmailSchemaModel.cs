using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; init; }
        public int ServiceId { get; set; }
        public string From { get; init; }
        public string DisplayName { get; init; }
        public string Name { get; init; }
        public string Subject { get; init; }
        public string Body { get; set; }
        public string ReplyTo { get; init; }
        public string ReplyToDisplayName { get; init; }
        public EmailFooterModel EmailFooter { get; set; }
        public List<EmailSchemaVariablesModel> EmailSchemaVariables { get; set; }
    }
}
