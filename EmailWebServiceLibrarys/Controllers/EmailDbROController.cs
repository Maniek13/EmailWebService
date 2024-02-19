using EmailWebServiceLibrarys.Interfaces;
using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrarys.Controllers
{
    public class EmailDbROController : IEmailDbROController
    {
        IEmailServiceContextBase _context;
        public EmailDbROController(IEmailServiceContextBase dbContext)
        {
            _context = dbContext;
        }

        public IAppPermisionDbModel GetAppPermision(string ServiceName)
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
        public IEmailConfigurationDbModel GetEmailConfiguration(string ServiceName)
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
        public List<EmailUsersDbModel> GetUsersList(int Id)
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
        public EmailSchemaDbModel GetEmailBodySchama(int Id)
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
