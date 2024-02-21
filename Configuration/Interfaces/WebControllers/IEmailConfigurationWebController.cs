using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailConfigurationWebController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);
        IResponseModel<EmailAccountConfigurationModel> GetEmailAccountConfiguration(string serviceName, HttpContext context);

        Task<IResponseModel<bool>> EditEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailAccountConfigurationAsync(string serviceName, int id, HttpContext context);
        #endregion
    }
}
