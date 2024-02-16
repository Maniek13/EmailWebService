namespace EmailWebService.Interfaces
{
    interface IEmailController
    {
        IEmailConfigurationModel GetEmailConfiguration(long ConfigurationId, string IdentityCode);
        Task<bool> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
        Task<bool> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
        Task<bool> SendEmailAsync(string IdentityCode, IEmailModel email);
        Task<bool> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList);
        string GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
