using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace EmailWebService.Controllers
{
    public class EmailController : IEmailController
    {
        public async Task<IEmailConfigurationModel> GetEmailConfigurationAsync(int ConfigurationId, string IdentityCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> SendEmailAsync(string IdentityCode, string ProviderName, IEmailModel email)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> SetEmailBodyAsync(string IdentityCode, string Name, string Body, List<(string Name, string Value)> VariablesList)
        {
            throw new NotImplementedException();
        }


        public async Task<IEmailModel> GetEmailBodyAsync(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList)
        {
            throw new NotImplementedException();
        }
    }
}
