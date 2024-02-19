using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailDbROController
    {
        IAppPermisionDbModel GetAppPermision(string ServiceName);
        IEmailConfigurationDbModel GetEmailConfiguration(string ServiceName);
        List<EmailUsersDbModel> GetUsersList(int Id);
        EmailSchemaDbModel GetEmailBodySchama(int Id);
    }
}
