using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailLogoWebController
    {
        IResponseModel<List<LogoModel>> GetEmailLogos(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context);
    }
}
