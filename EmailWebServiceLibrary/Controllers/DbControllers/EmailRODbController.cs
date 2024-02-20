using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Controllers.DbControllers
{
    public class EmailRODbController(IEmailServiceContextBase dbContext) : IEmailRODbController
    {
        private readonly IEmailServiceContextBase _context = dbContext;

        public IServicesPermisionsDbModel GetAppPermision(string serviceName)
        {
            try
            {
                return _context.AppPermisions.Where(el => el.ServiceName == serviceName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(string serviceName)
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
        public IEmailSchemaDbModel GetEmailSchemaDbModel(string ServiceName)
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
        public List<EmailUsersDbModel> GetUsersList(int id)
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
        public EmailSchemaDbModel GetEmailBodySchama(int id)
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
    }
}
