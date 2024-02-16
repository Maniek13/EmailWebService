using EmailWebService.Interfaces;

namespace EmailWebService.Controllers
{
    public class EmailController : IEmailController
    {
        IEmailDbControllerRO _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailController(IEmailDbControllerRO emailDbControllerRO, IEmailDbController emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }


        public IEmailConfigurationModel GetEmailConfiguration(long ConfigurationId, string IdentityCode)
        {
            try
            {
                long identityId = _emailDbControllerRO.GetIdentityCodeId(IdentityCode);
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
                long identityCodeId = _emailDbControllerRO.GetIdentityCodeId(IdentityCode);
                return _emailDbControllerRO.GetEmailBody(identityCodeId, SchemaName, VariablesList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
