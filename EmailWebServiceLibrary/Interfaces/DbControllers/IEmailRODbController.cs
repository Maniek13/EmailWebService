﻿using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailRODbController
    {
        IServicesPermisionsDbModel GetServicePermision(string serviceName);
        IEmailAccountConfigurationDbModel GetEmailAccountConfiguration(int serviceId);
        IEmailSchemaDbModel GetEmailSchemaDbModel(int serviceId);
        IEmailSchemaDbModel GetEmailBodySchama(int bodySchemaId);
        IEmailRecipientsListDbModel GetRecipientsList(int serviceId);
        List<IEmailRecipientDbModel> GetRecipients(int serviceId);
        IEmailFooterDbModel GetEmailFooter(int schemaId);
        List<IEmailSchemaVariablesDbModel> GetVariablesList(int schemaId);
        IEmailLogoDbModel GetEmailFooterLogo(int footerId);
        List<IEmailListRecipientDbModel> GetListRecipments(int listId);
        int GetListRecipmentId(int recipmentId, int listId);
        List<IEmailRecipientDbModel> GetRecipients();
    }
}
