using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrary.Models.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;

namespace EmailWebServiceLibrary.Helpers
{
    public static class ConversionHelper
    {
        #region convert to db models

        public static EmailRecipientsListDbModel ConvertToEmailRecipientsListDbModel(IEmailRecipientsListModel emailRecipientsList)
        {
            try
            {
                Collection<EmailRecipientDbModel> recipients = [];

                for (int i = 0; i < emailRecipientsList.Recipients.Count; ++i)
                {
                    recipients.Add(ConvertToEmailRecipientsDbModel(emailRecipientsList.Recipients[i]));
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

        public static EmailRecipientDbModel ConvertToEmailRecipientsDbModel(IEmailRecipientModel recipient)
        {
            try
            {
                return new EmailRecipientDbModel()
                {
                    Id = recipient.Id,
                    RecipientListId = recipient.RecipientsListId,
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
                ICollection<EmailSchemaVariablesDbModel> emailSchemaVariables = new List<EmailSchemaVariablesDbModel>();

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
                    TextHtml = emailFooter.TextHtml,
                    Logo = ConvertToLogoDbModel(emailFooter.Logo),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static LogoDbModel ConvertToLogoDbModel(ILogoModel logo)
        {
            try
            {
                var imageByteArray = Convert.FromBase64String(logo.FileBase64String);

                if (imageByteArray == null)
                    throw new Exception("Plik nie został ustawiony");

                return new LogoDbModel()
                {
                    Id = logo.Id,
                    EmailFooterId = logo.EmailFooterId,
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

        public static LogoDbModel ConvertToLogoDbModel(int EmailFooterId, IFormFile image, string name)
        {
            try
            {
                long fileSize = image.Length;
                string fileType = image.ContentType;

                if (fileSize > 0)
                {
                    using var stream = new MemoryStream();
                    image.CopyTo(stream);
                    var imageByteArray = stream.ToArray();

                    return new LogoDbModel()
                    {
                        EmailFooterId = EmailFooterId,
                        Name = name,
                        Type = image.ContentType,
                        FileByteArray = imageByteArray
                    };
                }

                throw new Exception("Plik nie został ustawiony");
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
            return new EmailSchemaVariablesModel()
            {
                Id = emailSchemaVariables.Id,
                Name = emailSchemaVariables.Name,
                Value = emailSchemaVariables.Value
            };
        }
        public static EmailRecipientsListModel ConvertToEmailRecipientsListModel(IEmailRecipientsListDbModel emailRecipientsListDb)
        {
            return new EmailRecipientsListModel()
            {
                Id = emailRecipientsListDb.Id,
                Name = emailRecipientsListDb.Name,
                ServiceId = emailRecipientsListDb.ServiceId
            };
        }

        public static EmailSchemaModel ConvertToEmailSchemaModel(IEmailSchemaDbModel emailSchema)
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

        public static EmailRecipientModel ConvertToEmailRecipientsModel(IEmailRecipientDbModel user)
        {
            return new EmailRecipientModel()
            {
                Id = user.Id,
                RecipientsListId = user.RecipientListId,
                Name = user.Name,
                EmailAdress = user.EmailAdress
            };
        }

        public static EmailAccountConfigurationModel ConvertToEmailAccountConfigurationModel(IEmailAccountConfigurationDbModel configuration)
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

        public static EmailFooterModel ConvertToEmailFooterModel(IEmailFooterDbModel emailFooterDb)
        {
            try
            {
                return new EmailFooterModel()
                {
                    Id = emailFooterDb.Id,
                    EmailSchemaId = emailFooterDb.EmailSchemaId,
                    TextHtml = emailFooterDb.TextHtml,
                    Logo = ConvertToLogoModel(emailFooterDb.Logo)
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static LogoModel ConvertToLogoModel(ILogoDbModel logo)
        {
            try
            {
                return new LogoModel()
                {
                    Id = logo.Id,
                    EmailFooterId = logo.EmailFooterId,
                    Name = logo.Name,
                    Type = logo.Type,
                    FileBase64String = Convert.ToBase64String(logo.FileByteArray)
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion


    }
}
