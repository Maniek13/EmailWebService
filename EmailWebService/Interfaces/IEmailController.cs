using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    interface IEmailController
    {
        Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, IEmailModel email);
        Task<IResponseModel<bool>> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList);
        IResponseModel<string> GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
