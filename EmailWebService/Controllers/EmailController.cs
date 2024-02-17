using EmailWebService.Interfaces;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class EmailController : IEmailController
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailController(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }


        public IEmailConfigurationModel GetEmailConfiguration(long ConfigurationId, string IdentityCode)
        {
            try
            {
                    long identityId = getIdentityCodeId(IdentityCode);
                    return _emailDbControllerRO.GetEmailConfiguration(identityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<bool> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> SendEmailAsync(string IdentityCode, IEmailModel email)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList)
        {
            throw new NotImplementedException();
        }


        public string GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList)
        {
            try
            {
                return _emailDbControllerRO.GetEmailBody(getIdentityCodeId(IdentityCode), SchemaName, VariablesList);  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region private functions
        private long getIdentityCodeId(string IdentityCode)
        {
            try
            {
                long identityCodeId = _emailDbControllerRO.GetIdentityCodeId(IdentityCode);

                var permision = getAppPermision(identityCodeId);
                if (permision != null)
                    return permision.IdentityCodeId;
  
                throw new Exception("App don't have permision to use email service\"");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private IAppPermisionModel getAppPermision(long IdentityCodeId)
        {
            try
            {
                return _emailDbControllerRO.GetAppPermision(IdentityCodeId, AppConfig.ServiceName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
