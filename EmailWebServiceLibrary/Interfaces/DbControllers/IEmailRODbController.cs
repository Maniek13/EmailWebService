using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IServicesPermisionsDbModel GetServicePermision(string serviceName);
        IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(int serviceId);
        IEmailSchemaDbModel GetEmailSchemaDbModel(int serviceId);
        IEmailSchemaDbModel GetEmailBodySchama(int id);
        List<EmailRecipientsListDbModel> GetRecipientsLists(int serviceId);
        List<EmailRecipientDbModel> GetRecipients(int serviceId);
    }
}
