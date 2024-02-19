using EmailWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailWebService.Interfaces
{
    interface IEmailServiceController
    {
        Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, [FromForm] EmailModel email, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(RequestModel<EmailBodySchemaModel> Request, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(RequestModel<EmailBodySchemaModel> Request, HttpContext Context);
        IResponseModel<string> GetEmailBody(RequestModel<EmailBodySchemaModel> Request, HttpContext Context);
        IResponseModel<List<UsersListModel>> GetUsersLists(RequestModel<string> Request, HttpContext Context);
        IResponseModel<List<EmailBodySchemaModel>> GetEmailBodySchamas(RequestModel<int> Request, HttpContext Context);
    }
}
