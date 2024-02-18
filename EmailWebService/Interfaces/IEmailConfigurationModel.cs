namespace EmailWebService.Interfaces
{
    public interface IEmailConfigurationModel
    {
        int Id { get; set; }
        string ProviderName { get; set; }
        string SMTP { get; set; }
        string Port { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
