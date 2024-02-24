using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task SetEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task EditEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task DeleteEmailConfigurationAsync(int id);

        #endregion

        #region email body

        Task SetEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task DeleteEmailBodySchemaAsync(int serviceId);

        #endregion

        #region recipient list
        Task SetRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel);
        Task EditRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel);
        Task DeleteRecipientsListAsync(int id);

        #endregion
        #region recipient
        Task SetRecipientAsync(IEmailRecipientDbModel recipientsDbModel);
        Task EditRecipientAsync(IEmailRecipientDbModel recipientsDbModel);
        Task DeleteRecipientAsync(int id);
        #endregion

        #region body variables
        Task EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariablesDbModel);
        #endregion
        #region logo
        Task EditLogoAsync(IEmailLogoDbModel logo);
        #endregion

        #region footer
        Task EditEmailFooterAsync(IEmailFooterDbModel footer);
        #endregion

    }
}
