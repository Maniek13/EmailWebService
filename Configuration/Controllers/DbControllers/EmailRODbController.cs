using Configuration.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.DbControllers
{
    public class EmailRODbController() : IEmailRODbController
    {
        public IServicesPermisionsDbModel GetServicePermision(string serviceName)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.ServicesPermisions.Where(el => el.ServiceName == serviceName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(int serviceId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailAccountConfiguration.Where(el => el.ServiceId == serviceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailSchemaDbModel GetEmailSchemaDbModel(int serviceId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailSchemas.Where(el => el.ServiceId == serviceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailSchemaDbModel GetEmailBodySchama(int id)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailSchemas.Where(el => el.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailFooterDbModel GetEmailFooter(int schemaId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.Footers.Where(el => el.EmailSchemaId == schemaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public ILogoDbModel GetEmailFooterLogo(int logoId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.Logos.Where(el => el.Id == logoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<IEmailRecipientDbModel> GetRecipients(int recipientsList)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                var list = _context.Recipients.Where(el => el.RecipientListId == recipientsList).ToList();
                List<IEmailRecipientDbModel> res = [];

                for (int i = 0; i < list.Count; ++i)
                {
                    res.Add(list[i]);
                }


                return res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public List<IEmailSchemaVariablesDbModel> GetVariablesList(int schemaId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return [.. _context.EmailSchemaVariables.Select(el => (IEmailSchemaVariablesDbModel)el).Where(el => el.EmailSchemaId == schemaId)];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEmailRecipientsListDbModel GetRecipientsList(int ServiceId)
        {
            try
            {
                EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.RecipientsList.Where(el => el.ServiceId == ServiceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
