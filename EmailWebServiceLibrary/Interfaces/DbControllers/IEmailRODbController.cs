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
        List<IEmailRecipmentDbModel> GetRecipients(int recipientsList);
        IEmailFooterDbModel GetEmailFooter(int schemaId);
        List<IEmailSchemaVariablesDbModel> GetVariablesList(int schemaId);
        IEmailLogoDbModel GetEmailFooterLogo(int footerId);
        IEmailListRecipientDbModel GetListRecipment(int id);
    }
}
