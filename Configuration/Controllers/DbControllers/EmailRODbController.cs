using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace Configuration.Controllers.DbControllers
{
    public class EmailRODbController(IEmailServiceContextBase dbContext) : IEmailRODbController
    {
        private readonly IEmailServiceContextBase _context = dbContext;


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
        public List<EmailRecipientDbModel> GetRecipients(int serviceId)
        {
            try
            {
                return _context.Recipients.Where(el => el.ServiceId == serviceId).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<EmailRecipientsListDbModel> GetRecipientsLists(int ServiceId)
        {
            try
            {
                return _context.RecipientsList.Where(el => el.ServiceId == ServiceId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
