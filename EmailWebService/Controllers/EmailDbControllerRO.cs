using EmailWebService.Data;
using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace EmailWebService.Controllers
{
    public class EmailDbControllerRO
    {
        EmailServiceContext context;
        public EmailDbControllerRO()
        {
            context = new(AppConfig.ConnectionStringRO);
        }

        public int GetIdentityCode(string IdentityCode)
        {
            try
            {
                return context.IdentityCodes.Where(el => el.IdentityCode == IdentityCode).FirstOrDefault().Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IAppPermisionModel GetAppPermision(string IdentityCodesId)
        {
            try
            {
                return ConvertToAppPermisoin(context.AppPermisions.Where(el => el.IdentityCodesId == IdentityCodesId).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEmailConfigurationModel GetEmailConfiguration(int IdentityCodesId)
        {
            try
            {
                int EmailConfigurationId =  context.AppEmailServiceSettings.Where(el => el.Id == IdentityCodesId).FirstOrDefault().EmailConfigurationId;
                return ConvertToEmailConfiguration(context.EmailConfigurationDb.Where(el => el.Id == EmailConfigurationId).FirstOrDefault());
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string GetEmailBody(int IdentityCodesId, string SchemaName, List<(string Name, string Value)> VariablesList)
        {
            try
            {
                var emailSchema = context.EmailSchemas.Where(el => el.Name == SchemaName).FirstOrDefault();
                if (emailSchema != null)
                {
                    string body = emailSchema.Body;

                    for(int i = 0; i < VariablesList.Count; i++)
                    {
                        body.Replace($"#{VariablesList[i].Name}#", VariablesList[i].Value);
                    }

                    return body;
                }
                throw new Exception($"Brak templejtki o nazwie {SchemaName}");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region private function
        private IEmailConfigurationModel ConvertToEmailConfiguration(EmailConfigurationDbModel email)
        {
            return new EmailConfigurationModel
            {
                Id = email.Id,
                ProviderName = email.ProviderName,
                SMTP = email.SMTP,
                Port = email.Port,
                Login = email.Login,
                Password = email.Password,
            };
        }

        private IAppPermisionModel ConvertToAppPermisoin(AppPermisionDbModel email)
        {
            return new AppPermisionModel
            {
                Id = email.Id,
                IdentityCodesId = email.IdentityCodesId,
                ServiceName = email.ServiceName,
            };
        }
        #endregion
    }
}
