using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IAppPermisionDbModel GetAppPermision(string ServiceName);
        IEmailConfigurationDbModel GetEmailConfiguration(string ServiceName);
        List<EmailUsersDbModel> GetUsersList(int Id);
        EmailSchemaDbModel GetEmailBodySchama(int Id);
    }
}
