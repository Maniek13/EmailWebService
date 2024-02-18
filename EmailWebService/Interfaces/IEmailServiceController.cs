using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailServiceController
    {
        Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, EmailModel email, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailBodyAsync(string IdentityCode, string SchemaName, string Body, List<(string Name, string Value)> VariablesList, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailBodyAsync(string IdentityCode, string SchemaName, string Body, List<(string Name, string Value)> VariablesList, HttpContext Context);
        IResponseModel<string> GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList, HttpContext Context);
    }
}
