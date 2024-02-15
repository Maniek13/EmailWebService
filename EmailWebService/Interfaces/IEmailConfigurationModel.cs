namespace EmailWebService.Interfaces
{
    public interface IEmailConfigurationModel
    {
        long Id { get; set; }
        string ProviderName { get; set; }
        string SMTP { get; set; }
        string Port { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
