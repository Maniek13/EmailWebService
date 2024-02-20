using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailFooterWebController
    {
        Task<IResponseModel<bool>> UpdateEmailFooterAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context);
    }
}
