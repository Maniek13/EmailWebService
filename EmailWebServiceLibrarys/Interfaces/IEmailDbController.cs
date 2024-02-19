using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailDbController
    {
        #region email config
        Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel Configuration);

        Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel Configuration);
        Task<bool> DeleteEmailConfigurationAsync(EmailConfigurationDbModel Configuration);
        #endregion
        #region email body

        Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables);
        Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables);
        Task<bool> DeleteEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables);
        #endregion

        #region user list
        Task<bool> SetUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel);
        Task<bool> UpdateUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel);
        Task<bool> DeleteUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel);
        #endregion
    }
}
