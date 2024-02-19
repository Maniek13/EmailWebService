namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailConfigurationModel
    {
        int Id { get; set; }
        public string Subject { get; set; }
        string From { get; set; }
        string ReplyTo { get; set; }
        string ReplyToDisplayName { get; set; }
        string DisplayName { get; set; }
        int ServiceId { get; set; }
        string SMTP { get; set; }
        int Port { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
