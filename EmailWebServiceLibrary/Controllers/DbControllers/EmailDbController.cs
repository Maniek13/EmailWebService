using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Controllers.DbControllers
{
    public class EmailDbController(IEmailServiceContextBase dbContext) : IEmailDbController
    {
        readonly IEmailServiceContextBase _context = dbContext;
        #region email config
        public Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<bool> DeleteEmailConfigurationAsync(EmailConfigurationDbModel configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region email body

        public Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<bool> DeleteEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region user list
        public Task<bool> SetUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<bool> UpdateUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<bool> DeleteUserListAsync(EmailUsersDbModel emailUsersListsDbModel, EmailUsersListDbModel emailUsersDbModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
