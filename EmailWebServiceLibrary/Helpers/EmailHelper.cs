using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace EmailWebServiceLibrary.Helpers
{
    public class EmailHelper
    {
        public async static Task SendEmail(IEmailSchemaModel emailSchema, List<IEmailRecipientModel> userList, IEmailAccountConfigurationModel configuration, IFormFileCollection atachments)
        {
            try
            {
                EmailHelper.CreateBody(emailSchema);
                var message = EmailHelper.CreateEmail(userList, emailSchema, atachments);

                using var smtpClient = new SmtpClient(configuration.SMTP);
                smtpClient.Port = configuration.Port;
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = configuration.Login,
                    Password = configuration.Password
                };
                await smtpClient.SendMailAsync(message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void CreateBody(IEmailSchemaModel schemaBody)
        {
            try
            {
                var variables = schemaBody.EmailSchemaVariables.ToList();

                if (variables.Count == 0)
                    return;

                if (schemaBody != null)
                {
                    string body = schemaBody.Body;

                    for (int i = 0; i < variables.Count; i++)
                    {
                        _ = body.Replace($"#{variables[i].Name}#", variables[i].Value);
                    }
                    schemaBody.Body = body;
                }

                throw new Exception("Msg don't hava a body");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static MailMessage CreateEmail(List<IEmailRecipientModel> users, IEmailSchemaModel emailSchema, IFormFileCollection atachments)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailSchema.From))
                    throw new Exception("Please set a sender email");
                if (users.Count == 0)
                    throw new Exception("Please set a receiver email");

                using MailMessage message = new();
                message.Subject = emailSchema.Subject;
                message.Body = emailSchema.Body;

                ContentType mimeType = new("text/html");

                string htmlBody = string.Format("<html>" +
                    "<body>" +
                    "<br />" +
                    "{0}" +
                    "<br />" +
                    "<img src=\"cid:Footer\" />" +
                    "{1}" +
                    "</body>" +
                    "</html>", emailSchema.Body, emailSchema.EmailFooter.TextHtml);

                using (AlternateView alternate = AlternateView.CreateAlternateViewFromString(emailSchema.Body, mimeType))
                {
                    message.AlternateViews.Add(alternate);


                    byte[] fileByteArray = System.Convert.FromBase64String(emailSchema.EmailFooter.Logo.Base64String);
                    using (MemoryStream fs = new(fileByteArray))
                    {
                        LinkedResource footer = new(fs, $"image/{emailSchema.EmailFooter.Logo.Type}")
                        {
                            ContentId = "Footer"
                        };
                        alternate.LinkedResources.Add(footer);
                    }

                    message.AlternateViews.Add(alternate);
                }

                message.From = new MailAddress(emailSchema.From, string.IsNullOrWhiteSpace(emailSchema.DisplayName) ? emailSchema.From : emailSchema.DisplayName);

                if (!string.IsNullOrWhiteSpace(emailSchema.ReplyTo))
                    message.ReplyTo = new MailAddress(emailSchema.ReplyTo, string.IsNullOrWhiteSpace(emailSchema.ReplyToDisplayName) ? emailSchema.ReplyTo : emailSchema.ReplyToDisplayName);


                for (int i = 0; i < users.Count; ++i)
                {
                    message.To.Add(new MailAddress(users[i].EmailAdress, string.IsNullOrWhiteSpace(users[i].Name) ? users[i].EmailAdress : users[i].Name));
                }


                if (atachments != null && atachments.Count != 0)
                    for (int i = 0; i < atachments.Count; ++i)
                    {
                        if (atachments[i] == null)
                            continue;

                        using var memStream = new MemoryStream();
                        var temp = atachments[i].OpenReadStream();
                        byte[] byteArray;

                        using (MemoryStream ms = new())
                        {
                            temp.CopyTo(ms);
                            byteArray = ms.ToArray();
                        }

                        memStream.Write(byteArray, 0, byteArray.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                        message.Attachments.Add(new Attachment(memStream, MediaTypeNames.Application.Octet));
                    }

                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
