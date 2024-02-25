using Configuration.Data;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Metadata;

namespace Configuration.Controllers.DbControllers
{
    public class EmailDbController() : IEmailDbController
    {
        #region body variables
        public async Task EditBodyVariablesAsync(IEmailSchemaVariablesDbModel emailSchemaVariablesDbModel)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailSchemaVariables.Update((EmailSchemaVariablesDbModel)emailSchemaVariablesDbModel);
                _ = await _context.SaveChangesAsync();
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                await _context.EmailAccountConfiguration.AddAsync((EmailAccountConfigurationDbModel)emailAccountConfiguration);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
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
            using EmailServiceContext _context = new(AppConfig.ConnectionString);
            try
            {
                await _context.Database.BeginTransactionAsync();

                EmailSchemaDbModel schema = new()
                {
                    ServiceId = emailSchema.ServiceId,
                    Name = emailSchema.Name,
                    Body = emailSchema.Body,
                    From = emailSchema.From,
                    DisplayName = emailSchema.DisplayName,
                    ReplyTo = emailSchema.ReplyTo,
                    ReplyToDisplayName = emailSchema.ReplyToDisplayName,
                    Subject = emailSchema.Subject
                };

                await _context.EmailSchemas.AddAsync(schema);
                await _context.EmailLogos.AddAsync(emailSchema.EmailFooter.Logo);
                await _context.SaveChangesAsync();


                emailSchema.EmailFooter.EmailSchemaId = schema.Id;
                emailSchema.EmailFooter.LogoId = emailSchema.EmailFooter.Logo.Id;
                await _context.EmailFooters.AddAsync(emailSchema.EmailFooter);
                await _context.SaveChangesAsync();

                for (int i = 0; i < emailSchema.EmailSchemaVariables.Count; ++i)
                {
                    emailSchema.EmailSchemaVariables.ElementAt(i).EmailSchemaId = schema.Id;
                    await _context.EmailSchemaVariables.AddAsync(emailSchema.EmailSchemaVariables.ElementAt(i));
                }
                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task EditEmailBodySchemaAsync(IEmailSchemaDbModel emailSchema)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailSchemas.Update((EmailSchemaDbModel)emailSchema);
                _context.EmailFooters.Update(emailSchema.EmailFooter);
                _context.EmailLogos.Update(emailSchema.EmailFooter.Logo);


                var dbList = _context.EmailSchemaVariables.Where(el => el.EmailSchemaId == emailSchema.Id).ToList();
                var toUpdate =dbList.Where(el => emailSchema.EmailSchemaVariables.Contains(el)).ToList();
                var toDelete = dbList.Where(el => !emailSchema.EmailSchemaVariables.Contains(el)).ToList();
                var toAdd = emailSchema.EmailSchemaVariables.Where(el => !dbList.Contains(el)).ToList();

                _context.EmailSchemaVariables.UpdateRange(toUpdate);
                _context.EmailSchemaVariables.RemoveRange(toDelete);
                for (int i = 0; i < toAdd.Count; ++i)
                {
                    toAdd[i].EmailSchemaId = emailSchema.Id;
                    _context.EmailSchemaVariables.Add(toAdd[i]);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteEmailBodySchemaAsync(int serviceId)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                var entity = _context.EmailSchemas.Where(el => el.ServiceId == serviceId).FirstOrDefault();
                _context.EmailSchemas.Remove(entity);

                var variables = _context.EmailSchemaVariables.Where(el => el.EmailSchemaId == entity.Id).ToList();
                _context.EmailSchemaVariables.RemoveRange(variables);

                var footer = _context.EmailFooters.Where(el => el.EmailSchemaId == entity.Id).FirstOrDefault();
                _context.EmailFooters.Remove(footer);


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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                await _context.EmailRecipients.AddAsync((EmailRecipientDbModel)recipientsDbModel);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailRecipients.Update((EmailRecipientDbModel)recipientsDbModel);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                var recipment = _context.EmailRecipients.Where(el => el.Id == id).FirstOrDefault();
                _context.EmailRecipients.Remove(recipment);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                await _context.EmailRecipientsLists.AddAsync((EmailRecipientsListDbModel)recipientsListDbModel);
                for (int i = 0; i < recipientsListDbModel.Recipients.Count; ++i)
                {
                    _context.EmailRecipients.AddAsync(recipientsListDbModel.Recipients.ElementAt(i));
                }
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
                if (recipientsListDbModel == null)
                    throw new Exception("Lista odbiorców nie może być pusta");

                if (recipientsListDbModel.Recipients.Count == 0)
                    throw new Exception("Lista odbiorców nie może być pusta");

                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailRecipientsLists.Update((EmailRecipientsListDbModel)recipientsListDbModel);

                var dbList = _context.EmailRecipients.Where(el => el.RecipientListId == recipientsListDbModel.Id).ToList();
                var toUpdate = dbList.Where(el => recipientsListDbModel.Recipients.Contains(el)).ToList();
                var ToRemove = dbList.Where(el => !recipientsListDbModel.Recipients.Contains(el)).ToList();
                var toAdd = recipientsListDbModel.Recipients.Where(el=> !dbList.Contains(el)).ToList();


                _context.EmailRecipients.UpdateRange(toUpdate);
                _context.EmailRecipients.RemoveRange(ToRemove);
                for (int i = 0; i < toAdd.Count; ++i)
                {
                    toAdd[i].RecipientListId = recipientsListDbModel.Id;
                    _context.EmailRecipients.Add(toAdd[i]);
                }

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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                var recipmentList = _context.EmailRecipientsLists.Where(el => el.Id == id).FirstOrDefault();
                _context.EmailRecipientsLists.Remove(recipmentList);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region logos
        public async Task EditLogoAsync(IEmailLogoDbModel logo)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailLogos.Update((EmailLogoDbModel)logo);
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
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                _context.EmailFooters.Update((EmailFooterDbModel)footer);
                _context.EmailLogos.Update(footer.Logo);

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
