using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailConfigurationController
    {
        IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(int ConfigurationId, string IdentityCode, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration, HttpContext Context);
    }
}
