using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailBodyWebController
    {
        #region email body
        IResponseModel<EmailSchemaModel> GetEmailBodySchema(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> EditEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, int id, HttpContext context);
        #endregion
    }
}
