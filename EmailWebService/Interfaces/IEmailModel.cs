namespace EmailWebService.Interfaces
{
    public interface IEmailModel
    {
        string From { get; set; }

        string? DisplayName { get; set; }
        List<string> To { get; set; }
        List<string>? Bcc { get; set; }

        List<string>? Cc { get; set; }
        string ReplyTo { get; set; }
        string? ReplyToName { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        FormFileCollection Atachments { get; set; }
    }
}
