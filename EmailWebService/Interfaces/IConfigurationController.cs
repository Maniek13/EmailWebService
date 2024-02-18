using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IConfigurationController
    {
        IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(int ConfigurationId, string IdentityCode);
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration);
    }
}
