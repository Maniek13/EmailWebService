using EmailWebService.Interfaces;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class EmailConfigurationController : ServiceControllerBase, IConfigurationController
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailConfigurationController(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController) : base(emailDbControllerRO, emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }

        public IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(int ConfigurationId, string IdentityCode)
        {
            try
            {
                int identityId = GetIdentityCodeId(IdentityCode);

                return new ResponseModel<IEmailConfigurationModel>()
                {
                    Data = _emailDbControllerRO.GetEmailConfiguration(identityId),
                    ResultCode = 200,
                    Message = "ok"
                };  
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEmailConfigurationModel>()
                {
                    Data = null,
                    ResultCode = 400,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = 400,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            throw new NotImplementedException();
        }
    }
}
