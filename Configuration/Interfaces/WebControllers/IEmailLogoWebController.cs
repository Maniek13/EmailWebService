using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailLogoWebController
    {
        IResponseModel<List<LogoModel>> GetEmailLogos(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context);
        Task<IResponseModel<bool>> AddEmailLogoAsync(string serviceName, [FromForm] LogoWithFileModel logo, HttpContext context);
    }
}
