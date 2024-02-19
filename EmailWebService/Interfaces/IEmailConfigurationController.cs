using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailConfigurationController
    {
        IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(RequestModel<int> Request, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(RequestModel<EmailConfigurationModel> Request, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(RequestModel<EmailConfigurationModel> Request, HttpContext Context);
    }
}
