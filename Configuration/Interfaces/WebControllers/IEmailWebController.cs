using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrarys.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailWebController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(string serviceName, EmailConfigurationModel configuration, HttpContext context);

        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(EmailConfigurationModel configuration, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailConfigurationAsync(int id, HttpContext context);
        #endregion
        #region email body

        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(int id, HttpContext context);
        #endregion
    }
}
