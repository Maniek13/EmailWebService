using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailLogoWebController
    {
        Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context);

        Task<IResponseModel<bool>> AddEmailLogoAsync(string serviceName, [FromForm] LogoWithFileModel logo, HttpContext context);
    }
}
