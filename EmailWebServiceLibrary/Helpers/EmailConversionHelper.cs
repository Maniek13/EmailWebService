using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrary.Models.Models;
using System.Collections.ObjectModel;

namespace EmailWebServiceLibrary.Helpers
{
    public static class EmailConversionHelper
    {
        #region convert to db models

        public static EmailRecipientsListDbModel ConvertToEmailRecipientsListDbModel(IEmailRecipientsListModel emailRecipientsList)
        {
            try
            {
                Collection<EmailListRecipientDbModel> recipients = [];

                for (int i = 0; i < emailRecipientsList.Recipients.Count; ++i)
                {
                    recipients.Add(ConvertToEmailListRecipientsDbModel(emailRecipientsList.Recipients[i]));
                }

                return new EmailRecipientsListDbModel()
                {
                    Id = emailRecipientsList.Id,
                    Name = emailRecipientsList.Name,
                    ServiceId = emailRecipientsList.ServiceId,
                    Recipients = recipients
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static EmailListRecipientDbModel ConvertToEmailListRecipientsDbModel(IEmailRecipientModel recipient)
        {
            try
            {
                return new EmailListRecipientDbModel()
                {
                    Id = recipient.Id,
                    RecipientListId = recipient.RecipientsListId,
                    RecipmentId = recipient.RecipmentId,
                    Recipment = new()
                    {
                        Id = recipient.RecipmentId,
                        Name = recipient.Name,
                        EmailAdress = recipient.EmailAdress,
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public static EmailRecipmentDbModel ConvertToEmailRecipientDbModel(IEmailRecipientModel recipient)
        {
            try
            {
                return new EmailRecipmentDbModel()
                {
                    Id = recipient.Id,
                    Name = recipient.Name,
                    EmailAdress = recipient.EmailAdress
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        public static ServicesPermisionsDbModel ConvertToServicePermisionDbModel(IServicesPermisionsDbModel appPermisionDb)
        {
            try
            {
                return new ServicesPermisionsDbModel()
                {
                    Id = appPermisionDb.Id,
                    ServiceName = appPermisionDb.ServiceName,
                    EmailAccountConfiguration = appPermisionDb.EmailAccountConfiguration,
                    EmailSchema = appPermisionDb.EmailSchema,
                    EmailRecipientList = appPermisionDb.EmailRecipientList,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public static EmailAccountConfigurationDbModel ConvertToEmailAccountConfigurationDbModel(IEmailAccountConfigurationModel emailConfigurationModel)
        {
            try
            {
                return new EmailAccountConfigurationDbModel()
                {
                    Id = emailConfigurationModel.Id,
                    ServiceId = emailConfigurationModel.ServiceId,
                    SMTP = emailConfigurationModel.SMTP,
                    Port = emailConfigurationModel.Port,
                    Login = emailConfigurationModel.Login,
                    Password = emailConfigurationModel.Password
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public static EmailSchemaDbModel ConvertToEmailSchemaDbModel(IEmailSchemaModel emailschema)
        {
            try
            {
                List<EmailSchemaVariablesDbModel> emailSchemaVariables = [];


                for (int i = 0; i < emailschema.EmailSchemaVariables.Count; ++i)
                {
                    emailSchemaVariables.Add(ConvertToEmailSchemaVariableDbModel(emailschema.EmailSchemaVariables[i]));
                }

                return new EmailSchemaDbModel()
                {
                    Id = emailschema.Id,
                    ServiceId = emailschema.ServiceId,
                    Name = emailschema.Name,
                    Body = emailschema.Body,
                    From = emailschema.From,
                    DisplayName = emailschema.DisplayName,
                    ReplyTo = emailschema.ReplyTo,
                    ReplyToDisplayName = emailschema.ReplyToDisplayName,
                    Subject = emailschema.Subject,
                    EmailFooter = ConvertToEmailFooterDbModel(emailschema.EmailFooter),
                    EmailSchemaVariables = emailSchemaVariables
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


        public static EmailSchemaVariablesDbModel ConvertToEmailSchemaVariableDbModel(IEmailSchemaVariablesModel emailSchemaVar)
        {
            try
            {
                return new EmailSchemaVariablesDbModel()
                {
                    Id = emailSchemaVar.Id,
                    EmailSchemaId = emailSchemaVar.EmailSchemaId,
                    Name = emailSchemaVar.Name,
                    Value = emailSchemaVar.Value
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static EmailFooterDbModel ConvertToEmailFooterDbModel(IEmailFooterModel emailFooter)
        {
            try
            {
                return new EmailFooterDbModel()
                {
                    Id = emailFooter.Id,
                    EmailSchemaId = emailFooter.EmailSchemaId,
                    LogoId = emailFooter.EmailLogoId,
                    TextHtml = emailFooter.TextHtml,
                    Logo = ConvertToLogoDbModel(emailFooter.Logo),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static EmailLogoDbModel ConvertToLogoDbModel(IEmailLogoModel logo)
        {
            try
            {
                var imageByteArray = Convert.FromBase64String(logo.FileBase64String);

                return imageByteArray == null
                    ? throw new Exception("Plik nie został ustawiony")
                    : new EmailLogoDbModel()
                    {
                        Id = logo.Id,
                        Name = logo.Name,
                        Type = logo.Type,
                        FileByteArray = imageByteArray
                    };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region convert to models


        public static EmailSchemaVariablesModel ConvertToEmailSchemaVariablesModel(IEmailSchemaVariablesDbModel emailSchemaVariables)
        {
            try
            {
                return new EmailSchemaVariablesModel()
                {
                    Id = emailSchemaVariables.Id,
                    EmailSchemaId = emailSchemaVariables.EmailSchemaId,
                    Name = emailSchemaVariables.Name,
                    Value = emailSchemaVariables.Value
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
        public static EmailRecipientsListModel ConvertToEmailRecipientsListModel(IEmailRecipientsListDbModel emailRecipientsListDb)
        {
            try
            {
                return new EmailRecipientsListModel()
                {
                    Id = emailRecipientsListDb.Id,
                    Name = emailRecipientsListDb.Name,
                    ServiceId = emailRecipientsListDb.ServiceId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public static EmailSchemaModel ConvertToEmailSchemaModel(IEmailSchemaDbModel emailSchema)
        {
            try
            {
                return new EmailSchemaModel()
                {
                    Id = emailSchema.Id,
                    ServiceId = emailSchema.ServiceId,
                    From = emailSchema.From,
                    DisplayName = emailSchema.DisplayName,
                    ReplyTo = emailSchema.ReplyTo,
                    ReplyToDisplayName = emailSchema.ReplyToDisplayName,
                    Name = emailSchema.Name,
                    Body = emailSchema.Body,
                    Subject = emailSchema.Subject
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }

        }

        public static EmailRecipientModel ConvertToEmailRecipientModel(IEmailListRecipientDbModel user)
        {
            try
            {
                return new EmailRecipientModel()
                {
                    Id = user.Id,
                    RecipientsListId = user.RecipientListId,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public static EmailRecipientModel ConvertToEmailRecipientModel(IEmailRecipmentDbModel user)
        {
            try
            {
                return new EmailRecipientModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    EmailAdress = user.EmailAdress
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }

        }

        public static EmailAccountConfigurationModel ConvertToEmailAccountConfigurationModel(IEmailAccountConfigurationDbModel configuration)
        {
            try
            {
                return new EmailAccountConfigurationModel()
                {
                    Id = configuration.Id,
                    ServiceId = configuration.ServiceId,
                    SMTP = configuration.SMTP,
                    Port = configuration.Port,
                    Login = configuration.Login,
                    Password = configuration.Password
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }

        }

        public static EmailFooterModel ConvertToEmailFooterModel(IEmailFooterDbModel emailFooterDb)
        {
            try
            {
                return new EmailFooterModel()
                {
                    Id = emailFooterDb.Id,
                    EmailSchemaId = emailFooterDb.EmailSchemaId,
                    EmailLogoId = emailFooterDb.LogoId,
                    TextHtml = emailFooterDb.TextHtml,
                    Logo = ConvertToLogoModel(emailFooterDb.Logo)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"ConvertToEmailFooterModel error: {ex.Message}", ex);
            }

        }

        public static EmailLogoModel ConvertToLogoModel(IEmailLogoDbModel logo)
        {
            try
            {
                if (logo == null)
                    return new EmailLogoModel();
                return new EmailLogoModel()
                {
                    Id = logo.Id,
                    Name = logo.Name,
                    Type = logo.Type,
                    FileBase64String = Convert.ToBase64String(logo.FileByteArray)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"ConvertToLogoModel error: {ex.Message}", ex);
            }
        }
        #endregion


    }
}
