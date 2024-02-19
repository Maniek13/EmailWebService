using EmailWebServiceLibrarys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    interface IDomainController
    {
        Task<IResponseModel<bool>> SendEmailAsync(string ServiceName, [FromForm] FormFileCollection Atachments, HttpContext Context);
    }
}
