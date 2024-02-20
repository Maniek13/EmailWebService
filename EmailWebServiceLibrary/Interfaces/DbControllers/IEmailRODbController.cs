using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IServicesPermisionsDbModel GetAppPermision(string ServiceName);
        IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(string ServiceName);
        IEmailSchemaDbModel GetEmailSchemaDbModel(string ServiceName);
        List<EmailUsersDbModel> GetUsersList(int Id);
        EmailSchemaDbModel GetEmailBodySchama(int Id);
    }
}
