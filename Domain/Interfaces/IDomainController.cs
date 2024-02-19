using EmailWebServiceLibrarys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    interface IDomainController
    {
        Task<IResponseModel<bool>> SendEmailsAsync(string ServiceName, [FromForm] IFormCollection Atachments, HttpContext Context);
    }
}
