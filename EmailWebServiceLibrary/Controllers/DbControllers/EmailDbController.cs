using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Controllers.DbControllers
{
    public class EmailDbController(IEmailServiceContextBase dbContext) : IEmailDbController
    {
        readonly IEmailServiceContextBase _context = dbContext;
        #region email config
        public Task<bool> SetEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration)
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

        public Task<bool> EditEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration)
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
        public Task<bool> DeleteEmailConfigurationAsync(EmailAccountConfigurationDbModel emailAccountConfiguration)
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
        public Task<bool> EditEmailBodySchemaAsync(EmailSchemaDbModel emailSchema, EmailSchemaVariablesDbModel emailSchemaVariables)
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
        public Task<bool> SetUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel)
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
        public Task<bool> EditUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel)
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
        public Task<bool> DeleteUserListAsync(EmailRecipientsDbModel emailUsersListsDbModel, EmailRecipientsListDbModel emailUsersDbModel)
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
