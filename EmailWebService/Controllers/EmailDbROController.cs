﻿using EmailWebService.Interfaces;

namespace EmailWebService.Controllers
{
    public class EmailDbROController : IEmailDbROController
    {
        IEmailServiceContextBase context;
        public EmailDbROController(IEmailServiceContextBase dbContext)
        {
            context = dbContext;
        }
        public int GetIdentityCodeId(string IdentityCode)
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
        public IAppPermisionDbModel GetAppPermision(int IdentityCodeId, string ServiceName)
        {
            try
            {
                return context.AppPermisions.Where(el => el.IdentityCodeId == IdentityCodeId && el.ServiceName == ServiceName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEmailConfigurationDbModel GetEmailConfiguration(int IdentityCodeId)
        {
            try
            {
                int EmailConfigurationId = context.AppEmailServiceSettings.Where(el => el.Id == IdentityCodeId).FirstOrDefault().EmailConfigurationId;
                return context.EmailConfiguration.Where(el => el.Id == EmailConfigurationId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string GetEmailBody(string SchemaName, List<(string Name, string Value)> VariablesList)
        {
            try
            {
                var emailSchema = context.EmailSchemas.Where(el => el.Name == SchemaName).FirstOrDefault();
                if (emailSchema != null)
                {
                    string body = emailSchema.Body;

                    for (int i = 0; i < VariablesList.Count; i++)
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
    }
}
