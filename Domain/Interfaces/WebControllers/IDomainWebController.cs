using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.WebControllers
{
    interface IDomainWebController
    {
           Task<IResponseModel<bool>> SendEmailsAsync(string serviceName, string? test, HttpContext context);
    }
}
