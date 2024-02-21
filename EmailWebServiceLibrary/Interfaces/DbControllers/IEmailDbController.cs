using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task<bool> SetEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> EditEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> DeleteEmailConfigurationAsync(int id);

        #endregion

        #region email body

        Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel emailSchema);
        Task<bool> EditEmailBodySchemaAsync(EmailSchemaDbModel emailSchema);
        Task<bool> DeleteEmailBodySchemaAsync(int id);

        #endregion

        #region recipient list
        Task<bool> SetRecipientsListAsync(EmailRecipientsListDbModel recipientsListDbModel);
        Task<bool> EditRecipientsListAsync(EmailRecipientsListDbModel recipientsListDbModel);
        Task<bool> DeleteRecipientsListAsync(int id);

        #endregion
        #region recipient
        Task<bool> SetRecipientAsync(EmailRecipientsDbModel recipientsDbModel);
        Task<bool> EditRecipientAsync(EmailRecipientsDbModel recipientsDbModel);
        Task<bool> DeleteRecipientAsync(int id);
        #endregion

        #region body variables
        Task<bool> EditBodyVariablesAsync(EmailSchemaVariablesDbModel emailSchemaVariablesDbModel);
        #endregion
        #region logo
        Task<bool> EditLogoAsync(LogoDbModel logo);
        #endregion

        #region footer
        Task<bool> EditEmailFooterAsync(EmailFooterDbModel footer);
        #endregion

    }
}
