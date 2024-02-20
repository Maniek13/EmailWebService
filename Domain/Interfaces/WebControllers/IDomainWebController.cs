using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.WebControllers
{
    interface IDomainWebController
    {
        Task<IResponseModel<bool>> SendEmailsAsync(string serviceName, [FromForm] IFormFileCollection atachments, HttpContext context);
    }
}
