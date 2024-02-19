using EmailWebServiceLibrarys.Interfaces;
using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrarys.Controllers
{
    public class EmailDbController : IEmailDbController
    {
        IEmailServiceContextBase _context;
        public EmailDbController(IEmailServiceContextBase dbContext)
        {
            _context = dbContext;
        }
        #region email config
        public Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel Configuration)
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

        public Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel Configuration)
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
        public Task<bool> DeleteEmailConfigurationAsync(EmailConfigurationDbModel Configuration)
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

        public Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables)
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
        public Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables)
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
        public Task<bool> DeleteEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema, EmailSchemaVariablesDbModel EmailSchemaVariables)
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
        public Task<bool> SetUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel)
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
        public Task<bool> UpdateUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel)
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
        public Task<bool> DeleteUserListAsync(EmailUsersDbModel EmailUsersListsDbModel, EmailUsersListDbModel EmailUsersDbModel)
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
