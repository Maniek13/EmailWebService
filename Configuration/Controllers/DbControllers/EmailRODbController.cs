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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailFooters.Where(el => el.EmailSchemaId == schemaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailLogoDbModel GetEmailFooterLogo(int logoId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailLogos.Where(el => el.Id == logoId).FirstOrDefault();
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                var list = _context.EmailRecipients.Where(el => el.RecipientListId == recipientsList).ToList();
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
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
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailRecipientsLists.Where(el => el.ServiceId == ServiceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
