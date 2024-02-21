using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailBodyWebController
    {
        IResponseModel<EmailSchemaModel> GetEmailBodySchema(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> AddEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> EditEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, int id, HttpContext context);
    }
}
