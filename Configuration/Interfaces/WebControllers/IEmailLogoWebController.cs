using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailLogoWebController
    {
        Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context);
    }
}
