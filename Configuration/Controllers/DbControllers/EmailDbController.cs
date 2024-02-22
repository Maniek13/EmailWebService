using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models.DbModels;

namespace Configuration.Controllers.DbControllers
{
    public class EmailDbController(IEmailServiceContextBase dbContext) : IEmailDbController
    {
        readonly IEmailServiceContextBase _context = dbContext;
        #region body variables
        public async Task EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariablesDbModel)
        {
            try
            {
                _context.EmailSchemaVariables.Update((EmailSchemaVariablesDbModel)emailSchemaVariablesDbModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region email config
        public async Task SetEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration)
        {
            try
            {
                await _context.EmailSchemaVariables.AddAsync((EmailSchemaVariablesDbModel)emailAccountConfiguration);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditEmailConfigurationAsync(IEmailAccountConfigurationDbModel emailAccountConfiguration)
        {
            try
            {
                _context.EmailAccountConfiguration.Update((EmailAccountConfigurationDbModel)emailAccountConfiguration);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteEmailConfigurationAsync(int id)
        {
            try
            {
                var entity = _context.EmailAccountConfiguration.Where(el => el.Id == id).FirstOrDefault();
                _context.EmailAccountConfiguration.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region email body

        public async Task SetEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema)
        {
            try
            {
                await _context.EmailSchemas.AddAsync((EmailSchemaDbModel)emailSchema);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema)
        {
            try
            {
                _context.EmailSchemas.Update((EmailSchemaDbModel)emailSchema);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteEmailBodySchemaAsync(int id)
        {
            try
            {
                var entity = _context.EmailSchemaVariables.Where(el => el.Id == id).FirstOrDefault();
                _context.EmailSchemaVariables.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region recipient
        public async Task SetRecipientAsync(IEmailRecipientDbModel recipientsDbModel)
        {
            try
            {
                await _context.Recipients.AddAsync((EmailRecipientDbModel)recipientsDbModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task EditRecipientAsync(IEmailRecipientDbModel recipientsDbModel)
        {
            try
            {
                _context.Recipients.Update((EmailRecipientDbModel)recipientsDbModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteRecipientAsync(int id)
        {
            try
            {
                var entity = _context.Recipients.Where(el => el.Id == id).FirstOrDefault();
                _context.Recipients.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region recipients  list
        public async Task SetRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
        {
            try
            {
                await _context.RecipientsList.AddAsync((EmailRecipientsListDbModel)recipientsListDbModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task EditRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
        {
            try
            {
                _context.RecipientsList.Update((EmailRecipientsListDbModel)recipientsListDbModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteRecipientsListAsync(int id)
        {
            try
            {
                var entity = _context.RecipientsList.Where(el => el.Id == id).FirstOrDefault();
                _context.RecipientsList.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region logos
        public async Task EditLogoAsync(ILogoDbModel logo)
        {
            try
            {
                _context.Logos.Update((LogoDbModel)logo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region footers
        public async Task EditEmailFooterAsync(IEmailFooterDbModel footer)
        {
            try
            {
                _context.Footers.Update((EmailFooterDbModel)footer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
