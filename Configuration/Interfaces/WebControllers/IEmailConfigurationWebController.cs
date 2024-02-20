using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailConfigurationWebController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);

        Task<IResponseModel<bool>> EditEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailAccountConfigurationAsync(string serviceName, int id, HttpContext context);
        #endregion
    }
}
