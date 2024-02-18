using EmailWebService.Interfaces;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class EmailServiceController : ServiceControllerBase, IEmailController
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailServiceController(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController) : base(emailDbControllerRO, emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }

        public async Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, IEmailModel email)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponseModel<bool>> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList)
        {
            throw new NotImplementedException();
        }

        public IResponseModel<string> GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList)
        {
            try
            {
                return new ResponseModel<string>()
                {
                    Data = _emailDbControllerRO.GetEmailBody(GetIdentityCodeId(IdentityCode), SchemaName, VariablesList),
                    ResultCode = 200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<string>()
                {

                    Data = null,
                    ResultCode = 200,
                    Message = ex.Message
                };
            }
        }
    }
}
