using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Interfaces.DbControllers
{
    public interface IEmailDbController
    {
        #region email config

        Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel configuration);
        Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel configuration);
        Task<bool> DeleteEmailConfigurationAsync(EmailConfigurationDbModel configuration);

        #endregion

        #region email body

        Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);
        Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);
        Task<bool> DeleteEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables);

        #endregion

        #region user list
        Task<bool> SetUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel);
        Task<bool> UpdateUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel);
        Task<bool> DeleteUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel);

        #endregion
    }
}
