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
        public List<IEmailRecipmentDbModel> GetRecipients(int recipientsListId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                var recipientsDb = _context.EmailRecipients.Join(
                    _context.EmailListRecipients,
                    recipients => recipients.Id,
                    listRecipments => listRecipments.RecipmentId,
                    (recipient, listRecipment) => new { recipient, listRecipment }
                    ).Where(el => el.listRecipment.RecipientListId == recipientsListId).ToList();


                List<IEmailRecipmentDbModel> res = [];

                for (int i = 0; i < recipientsDb.Count; ++i)
                {
                    res.Add(recipientsDb.ElementAt(i).recipient);
                }


                return res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEmailListRecipientDbModel GetListRecipment(int id)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailListRecipients.Where(el => el.Id == id).FirstOrDefault();
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
