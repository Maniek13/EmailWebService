using Configuration.Data;
using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace Configuration.Controllers.DbControllers
{
    public class EmailRODbController(EmailServiceContextRO dbContext) : IEmailRODbController
    {
        private readonly EmailServiceContextRO _context = dbContext;


        public IServicesPermisionsDbModel GetServicePermision(string serviceName)
        {
            try
            {
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
                return _context.RecipientsList.Where(el => el.ServiceId == ServiceId).FirstOrDefault(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
