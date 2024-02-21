using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Controllers.DbControllers
{
    public class EmailDbController(IEmailServiceContextBase dbContext) : IEmailDbController
    {
        readonly IEmailServiceContextBase _context = dbContext;
        #region body variables
        public async Task<bool> EditBodyVariablesAsync(EmailSchemaVariablesDbModel emailSchemaVariablesDbModel) => throw new NotImplementedException();
        #endregion

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
        public Task<bool> DeleteEmailConfigurationAsync(int id)
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

        public Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel emailSchema)
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
        public Task<bool> EditEmailBodySchemaAsync(EmailSchemaDbModel emailSchema)
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
        public Task<bool> DeleteEmailBodySchemaAsync(int id)
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
        #region recipient
        public async Task<bool> SetRecipientAsync(EmailRecipientsDbModel recipientsDbModel) => throw new NotImplementedException();
        public async Task<bool> EditRecipientAsync(EmailRecipientsDbModel recipientsDbModel) => throw new NotImplementedException();
        public async Task<bool> DeleteRecipientAsync(int id) => throw new NotImplementedException();
        #endregion
        #region recipients  list
        public Task<bool> SetRecipientsListAsync(EmailRecipientsListDbModel recipientsListDbModel)
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
        public Task<bool> EditRecipientsListAsync(EmailRecipientsListDbModel recipientsListDbModel)
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
        public Task<bool> DeleteRecipientsListAsync(int id)
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

        #region logos
        public async Task<bool> EditLogoAsync(LogoDbModel logo) => throw new NotImplementedException();
        #endregion

        #region footers
        public async Task<bool> EditEmailFooterAsync(EmailFooterDbModel footer) => throw new NotImplementedException();
        #endregion
    }
}
