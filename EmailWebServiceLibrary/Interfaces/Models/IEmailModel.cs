
using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailModel
    {
        string From { get; set; }

        string? DisplayName { get; set; }
        List<string> To { get; set; }
        string ReplyTo { get; set; }
        string? ReplyToName { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        FormFileCollection Atachments { get; set; }
    }
}
