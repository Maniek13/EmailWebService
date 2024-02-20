using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailLogoWebController
    {
        Task<IResponseModel<bool>> UpdateEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context);
    }
}
