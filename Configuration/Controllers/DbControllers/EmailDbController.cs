using Configuration.Data;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task DeleteEmailConfigurationAsync(int serviceId)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                var entity = _context.EmailAccountConfiguration.Where(el => el.ServiceId == serviceId).FirstOrDefault();
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
                await _context.SaveChangesAsync();

                for (int i = 0; i < emailSchema.EmailSchemaVariables.Count; ++i)
                {
                    emailSchema.EmailSchemaVariables.ElementAt(i).EmailSchemaId = schema.Id;
                    await _context.EmailSchemaVariables.AddAsync(emailSchema.EmailSchemaVariables.ElementAt(i));
                }

                await _context.SaveChangesAsync();




                if (emailSchema.EmailFooter != null)
                {

                    if (emailSchema.EmailFooter.Logo != null)
                    {
                        if (emailSchema.EmailFooter.Logo.Id != 0)
                            _context.EmailLogos.Update(emailSchema.EmailFooter.Logo);
                        else
                            await _context.EmailLogos.AddAsync(emailSchema.EmailFooter.Logo);
                        await _context.SaveChangesAsync();
                    }

                    emailSchema.EmailFooter.EmailSchemaId = schema.Id;
                    emailSchema.EmailFooter.LogoId = emailSchema.EmailFooter.Logo.Id;
                    await _context.EmailFooters.AddAsync(emailSchema.EmailFooter);
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
            using EmailServiceContext _context = new(AppConfig.ConnectionString);
            try
            {
                await _context.Database.BeginTransactionAsync();

                _context.EmailSchemas.Update((EmailSchemaDbModel)emailSchema);
                await _context.SaveChangesAsync();
                _context.EmailFooters.Update(emailSchema.EmailFooter);
                await _context.SaveChangesAsync();
                _context.EmailLogos.Update(emailSchema.EmailFooter.Logo);
                await _context.SaveChangesAsync();


                var dbList = _context.EmailSchemaVariables.Where(el => el.EmailSchemaId == emailSchema.Id).ToList();
                var toUpdate = dbList.Where(el => emailSchema.EmailSchemaVariables.Contains(el)).ToList();
                var toDelete = dbList.Where(el => !emailSchema.EmailSchemaVariables.Contains(el)).ToList();
                var toAdd = emailSchema.EmailSchemaVariables.Where(el => !dbList.Contains(el)).ToList();

                _context.EmailSchemaVariables.UpdateRange(toUpdate);
                await _context.SaveChangesAsync();

                _context.EmailSchemaVariables.RemoveRange(toDelete);
                await _context.SaveChangesAsync();

                for (int i = 0; i < toAdd.Count; ++i)
                {
                    toAdd[i].EmailSchemaId = emailSchema.Id;
                    _context.EmailSchemaVariables.Add(toAdd[i]);
                    await _context.SaveChangesAsync();
                }

                for (int i = 0; i < toUpdate.Count; ++i)
                {
                    _context.EmailSchemaVariables.Update(toUpdate[i]);
                    await _context.SaveChangesAsync();
                }

                await _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
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

        #region add recipient to list
        public async Task AddRecipientToLisAsync(int recipientsListId, int recipientId)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                await _context.EmailListRecipients.AddAsync(new EmailListRecipientDbModel()
                {
                    RecipientListId = recipientsListId,
                    RecipientId = recipientId
                });
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
                var recipment = _context.EmailListRecipients.Where(el => el.Id == id).FirstOrDefault();
                _context.EmailListRecipients.Remove(recipment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region recipients list
        public async Task SetRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
        {
            using EmailServiceContext _context = new(AppConfig.ConnectionString);
            try
            {
                _context.Database.BeginTransaction();

                EmailRecipientsListDbModel emailRecipientsListDbModel = new()
                {
                    Name = recipientsListDbModel.Name,
                    ServiceId = recipientsListDbModel.ServiceId
                };

                await _context.EmailRecipientsLists.AddAsync(emailRecipientsListDbModel);
                await _context.SaveChangesAsync();

                if (recipientsListDbModel.Recipients != null)
                {
                    for (int i = 0; i < recipientsListDbModel.Recipients.Count; ++i)
                    {
                        EmailListRecipientDbModel listRecipientToSave = new()
                        {
                            RecipientListId = emailRecipientsListDbModel.Id,
                        };

                        var listRecipient = recipientsListDbModel.Recipients.ElementAt(i);
                        var recipient = _context.EmailRecipients.Where(el => el.Id == listRecipient.RecipientId).FirstOrDefault();

                        EmailRecipientDbModel recipmentDbModel = new()
                        {
                            Name = listRecipient.Recipient.Name,
                            EmailAdress = listRecipient.Recipient.EmailAdress,
                        };

                        if (recipient == null)
                        {
                            await _context.EmailRecipients.AddAsync(recipmentDbModel);
                            await _context.SaveChangesAsync();
                            listRecipientToSave.RecipientId = recipmentDbModel.Id;
                        }
                        else
                        {
                            _context.EmailRecipients.Update(recipient);
                            await _context.SaveChangesAsync();
                            listRecipientToSave.RecipientId = recipient.Id;
                        }

                        await _context.EmailListRecipients.AddAsync(listRecipientToSave);
                        await _context.SaveChangesAsync();
                    }
                }

                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditRecipientsListAsync(IEmailRecipientsListDbModel recipientsListDbModel)
        {
            using EmailServiceContext _context = new(AppConfig.ConnectionString);
            try
            {
                _context.Database.BeginTransaction();
                if (recipientsListDbModel == null)
                    throw new Exception("Lista odbiorców nie może być pusta");


                EmailRecipientsListDbModel emailRecipment = new()
                {
                    Id = recipientsListDbModel.Id,
                    Name = recipientsListDbModel.Name,
                    ServiceId = recipientsListDbModel.ServiceId
                };

                _context.EmailRecipientsLists.Update(emailRecipment);
                await _context.SaveChangesAsync();


                for (int i = 0; i < recipientsListDbModel.Recipients.Count; ++i)
                {
                    int id = recipientsListDbModel.Recipients.ElementAt(i).Recipient.Id;

                    var recipient = _context.EmailRecipients.Where(el => el.Id == id).AsNoTracking().FirstOrDefault();

                    if (recipient != null)
                        _context.EmailRecipients.Update(recipientsListDbModel.Recipients.ElementAt(i).Recipient);
                    else
                        await _context.EmailRecipients.AddAsync(recipientsListDbModel.Recipients.ElementAt(i).Recipient);

                    await _context.SaveChangesAsync();
                    
                }


                var dbList = _context.EmailListRecipients.Where(el => el.RecipientListId == recipientsListDbModel.Id).ToList();

                for (int i = 0; i < dbList.Count; ++i)
                {
                    EmailListRecipientDbModel listRecipient = null;
                    if (dbList[i].Recipient != null)
                    {
                        listRecipient = recipientsListDbModel.Recipients.Where(el => el.Recipient.Id == dbList[i].Recipient.Id).FirstOrDefault();
                    }
                    

                    if (listRecipient != null)
                        _context.EmailListRecipients.Update(dbList[i]);
                    else
                        _context.EmailListRecipients.Remove(dbList[i]);

                    await _context.SaveChangesAsync();
                }


                for (int i = 0; i < recipientsListDbModel.Recipients.Count; ++i)
                {
                    var listRecipient = dbList.Where(el => el.Id == recipientsListDbModel.Recipients.ElementAt(i).Id).FirstOrDefault();
                    if (listRecipient == null)
                        _context.EmailListRecipients.Add(new EmailListRecipientDbModel()
                        {
                            RecipientId = recipientsListDbModel.Recipients.ElementAt(i).Recipient.Id,
                            RecipientListId = recipientsListDbModel.Id
                        });

                    await _context.SaveChangesAsync();
                }


                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteRecipientsListAsync(int recipientListId)
        {
            try
            {
                using EmailServiceContext _context = new(AppConfig.ConnectionString);
                var recipmentList = _context.EmailRecipientsLists.Where(el => el.Id == recipientListId).FirstOrDefault();
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
