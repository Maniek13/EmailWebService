using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailFooterWebController
    {
        IResponseModel<List<EmailFooterModel>> GetEmailFooters(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> EditEmailFooterAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
    }
}
