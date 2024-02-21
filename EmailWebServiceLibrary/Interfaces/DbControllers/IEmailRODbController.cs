using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IServicesPermisionsDbModel GetAppPermision(string ServiceName);
        IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(string ServiceName);
        IEmailSchemaDbModel GetEmailSchemaDbModel(string ServiceName);
        List<EmailRecipientsDbModel> GetUsersList(int Id);
        EmailSchemaDbModel GetEmailBodySchama(int Id);
        List<EmailRecipientsListDbModel> GetRecipientsLists();
        List<EmailRecipientsDbModel> GetRecipients();
        List<EmailFooterDbModel> GetFooters();
        List<LogoDbModel> GetLogos();
        List<EmailSchemaVariablesDbModel> GetBodySchemaVariables();
    }
}
