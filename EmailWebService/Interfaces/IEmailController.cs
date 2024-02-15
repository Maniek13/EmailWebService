using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailController
    {
        Task<IEmailConfigurationModel> GetEmailConfigurationAsync(int ConfigurationId, string IdentityCode);
        Task<bool> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
        Task<bool> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
        Task<bool> SendEmailAsync(string IdentityCode, string ProviderName, IEmailModel email);
        Task<bool> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList);
        Task<IEmailModel> GetEmailBodyAsync(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
