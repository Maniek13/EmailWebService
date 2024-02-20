using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailWebController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);

        Task<IResponseModel<bool>> UpdateEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailAccountConfigurationAsync(string serviceName, int id, HttpContext context);
        #endregion
        #region email body

        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, int id, HttpContext context);
        #endregion
    }
}
