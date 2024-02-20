using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task<bool> SetEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> UpdateEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration);
        Task<bool> DeleteEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration);

        #endregion

        #region email body

        Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);
        Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);
        Task<bool> DeleteEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);

        #endregion

        #region user list
        Task<bool> SetUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel);
        Task<bool> UpdateUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel);
        Task<bool> DeleteUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel);

        #endregion
    }
}
