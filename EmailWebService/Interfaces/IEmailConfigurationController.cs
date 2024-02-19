using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailConfigurationController
    {
        IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(Request<int> Request, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(Request<EmailConfigurationModel> Request, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(Request<EmailConfigurationModel> Request, HttpContext Context);
    }
}
