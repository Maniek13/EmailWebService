using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task SetEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task EditEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task DeleteEmailConfigurationAsync(int servicesId);

        #endregion

        #region email body

        Task SetEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task DeleteEmailBodySchemaAsync(int serviceId);

        #endregion

        #region recipient list
        Task SetRecipientsListAsync(IEmailRecipientsListDbModel listRecipients);
        Task EditRecipientsListAsync(IEmailRecipientsListDbModel listRecipients);
        Task DeleteRecipientsListAsync(int recipientListId);

        #endregion
        #region recipient
        Task SetRecipientAsync(IEmailRecipientDbModel recipient);
        Task EditRecipientAsync(IEmailRecipientDbModel recipient);
        Task DeleteRecipientAsync(int recipientId);
        #endregion

        #region body variables
        Task EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariables);
        #endregion
        #region logo
        Task EditLogoAsync(IEmailLogoDbModel logo);
        #endregion

        #region footer
        Task EditEmailFooterAsync(IEmailFooterDbModel footer);
        #endregion
        #region list recipments
        Task AddRecipientToLisAsync(int recipientsListId, int recipientId);
        #endregion

    }
}
