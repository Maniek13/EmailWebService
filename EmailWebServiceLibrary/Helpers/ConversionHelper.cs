﻿using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Helpers
{
    public static class ConversionHelper
    {
        #region convert to db models
        public static ServicesPermisionsDbModel ConvertToAppPermisionDbModel(IServicesPermisionsDbModel appPermisionDb)
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
        public static EmailAccountConfigurationDbModel ConvertToEmailAccountConfigurationDbModel(IEmailAccountConfigurationModel emailConfigurationModel)
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
        #endregion

        #region convert to models

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

        public static EmailRecipientModel ConvertToEmailUserModel(IEmailRecipientDbModel user)
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

        #endregion

        public static ILogoDbModel ConvertToLogoDbModel(int EmailFooterId, IFormFile image, string name)
        {
            try
            {
                long fileSize = image.Length;
                string fileType = image.ContentType;

                if (fileSize > 0)
                {
                    using (var stream = new MemoryStream())
                    {
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
                }

                throw new ArgumentNullException("Plik nie został ustawiony");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
