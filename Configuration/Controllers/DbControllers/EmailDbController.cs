using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;

namespace Configuration.Controllers.DbControllers
{
    public class EmailDbController(IEmailServiceContextBase dbContext) : IEmailDbController
    {
        readonly IEmailServiceContextBase _context = dbContext;
        #region body variables
        public async Task<bool> EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariablesDbModel) => throw new NotImplementedException();
        #endregion

        #region email config
        public Task<bool> SetEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration)
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

        public Task<bool> EditEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration)
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

        public Task<bool> SetEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema)
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
        public Task<bool> EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema)
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
        public async Task<bool> SetRecipientAsync(IEmailRecipientDbModel recipientsDbModel) => throw new NotImplementedException();
        public async Task<bool> EditRecipientAsync(IEmailRecipientDbModel recipientsDbModel) => throw new NotImplementedException();
        public async Task<bool> DeleteRecipientAsync(int id) => throw new NotImplementedException();
        #endregion
        #region recipients  list
        public Task<bool> SetRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
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
        public Task<bool> EditRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
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
        public async Task<bool> EditLogoAsync(ILogoDbModel logo) => throw new NotImplementedException();
        #endregion

        #region footers
        public async Task<bool> EditEmailFooterAsync(IEmailFooterDbModel footer) => throw new NotImplementedException();
        #endregion
    }
}
