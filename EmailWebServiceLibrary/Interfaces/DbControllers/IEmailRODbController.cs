using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IServicesPermisionsDbModel GetServicePermision(string serviceName);
        IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(int serviceId);
        IEmailSchemaDbModel GetEmailSchemaDbModel(int serviceId);
        IEmailSchemaDbModel GetEmailBodySchama(int id);
        IEmailRecipientsListDbModel GetRecipientsList(int serviceId);
        List<IEmailRecipientDbModel> GetRecipients(int recipientsList);
        IEmailFooterDbModel GetEmailFooter(int schemaId);
        List<IEmailSchemaVariablesDbModel> GetVariablesList(int schemaId);
        ILogoDbModel GetEmailFooterLogo(int footerId);
    }
}
