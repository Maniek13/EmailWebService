using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task<bool> SetEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> EditEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> DeleteEmailConfigurationAsync(int id);

        #endregion

        #region email body

        Task<bool> SetEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task<bool> EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema);
        Task<bool> DeleteEmailBodySchemaAsync(int id);

        #endregion

        #region recipient list
        Task<bool> SetRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel);
        Task<bool> EditRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel);
        Task<bool> DeleteRecipientsListAsync(int id);

        #endregion
        #region recipient
        Task<bool> SetRecipientAsync(IEmailRecipientDbModel recipientsDbModel);
        Task<bool> EditRecipientAsync(IEmailRecipientDbModel recipientsDbModel);
        Task<bool> DeleteRecipientAsync(int id);
        #endregion

        #region body variables
        Task<bool> EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariablesDbModel);
        #endregion
        #region logo
        Task<bool> EditLogoAsync(ILogoDbModel logo);
        #endregion

        #region footer
        Task<bool> EditEmailFooterAsync(IEmailFooterDbModel footer);
        #endregion

    }
}
