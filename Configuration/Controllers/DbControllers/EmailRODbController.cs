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
        public IEmailSchemaDbModel GetEmailBodySchama(int emailSchemaId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailSchemas.Where(el => el.Id == emailSchemaId).FirstOrDefault();
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

        public int GetListREcipmentId(int recipmentId, int listId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailListRecipients.Where(el => el.RecipientListId == listId && el.RecipientId == recipmentId).FirstOrDefault().Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<IEmailRecipientDbModel> GetRecipients(int recipientsListId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                var recipientsDb = _context.EmailRecipients.Join(
                    _context.EmailListRecipients,
                    recipients => recipients.Id,
                    listRecipments => listRecipments.RecipientId,
                    (recipient, listRecipment) => new { recipient, listRecipment }
                    ).Where(el => el.listRecipment.RecipientListId == recipientsListId).ToList();


                List<IEmailRecipientDbModel> responseRecipients = [];

                for (int i = 0; i < recipientsDb.Count; ++i)
                {
                    responseRecipients.Add(recipientsDb.ElementAt(i).recipient);
                }


                return responseRecipients;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<IEmailListRecipientDbModel> GetListRecipments(int recipmnetListId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailListRecipients.Select(el => (IEmailListRecipientDbModel)el).Where(el => el.RecipientListId == recipmnetListId).ToList();
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

        public IEmailRecipientsListDbModel GetRecipientsList(int serviceId)
        {
            try
            {
                using EmailServiceContextRO _context = new(AppConfig.ConnectionStringRO);
                return _context.EmailRecipientsLists.Where(el => el.ServiceId == serviceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
