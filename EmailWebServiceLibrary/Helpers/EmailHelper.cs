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
                using var smtpClient = new SmtpClient(configuration.SMTP);
                smtpClient.EnableSsl = true;
                smtpClient.Port = configuration.Port;
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = configuration.Login,
                    Password = configuration.Password
                };

                EmailHelper.CreateBody(emailSchema);
                ContentType mimeType = new("text/html");

                using var mailMessage = new MailMessage();
                using var memoryStream = new MemoryStream();
                using AlternateView alternate = AlternateView.CreateAlternateViewFromString(emailSchema.Body, mimeType);

                if (emailSchema.EmailFooter != null && emailSchema.EmailFooter.Id > 0)
                {
                    AddFooterToBody(emailSchema);
                    AddAlternateFooterImage(alternate, emailSchema);
                    mailMessage.AlternateViews.Add(alternate);
                }

                var message = EmailHelper.CreateEmail(mailMessage, memoryStream, userList, emailSchema, atachments);

                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"SendEmail error: {ex.Message}", ex);
            }
        }

        public static void CreateBody(IEmailSchemaModel schemaBody)
        {
            try
            {
                if (schemaBody == null || String.IsNullOrWhiteSpace(schemaBody.Body))
                    throw new Exception("Wiadomość nie posiada treśći");

                if (schemaBody.EmailSchemaVariables == null || schemaBody.EmailSchemaVariables.Count == 0)
                    return;
                string body = schemaBody.Body;

                var variables = schemaBody.EmailSchemaVariables.ToList();
                for (int i = 0; i < variables.Count; i++)
                {
                    _ = body.Replace($"#{variables[i].Name}#", variables[i].Value);
                }

                schemaBody.Body = body;

            }
            catch (Exception ex)
            {
                throw new Exception($"CreateBody error: {ex.Message}", ex);
            }
        }

        public static MailMessage CreateEmail(MailMessage message, MemoryStream memStream, List<IEmailRecipientModel> toRecipients, IEmailSchemaModel emailSchema, IFormFileCollection atachments)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailSchema.From))
                    throw new Exception("Nie ustawiono nadawcy");
                if (toRecipients.Count == 0)
                    throw new Exception("Nie ustawiono odbiorcy/ów");

                message.Subject = emailSchema.Subject;
                message.Body = emailSchema.Body;


                message.From = new MailAddress(emailSchema.From, string.IsNullOrWhiteSpace(emailSchema.DisplayName) ? emailSchema.From : emailSchema.DisplayName);

                if (!string.IsNullOrWhiteSpace(emailSchema.ReplyTo))
                    message.ReplyTo = new MailAddress(emailSchema.ReplyTo, string.IsNullOrWhiteSpace(emailSchema.ReplyToDisplayName) ? emailSchema.ReplyTo : emailSchema.ReplyToDisplayName);


                for (int i = 0; i < toRecipients.Count; ++i)
                    message.To.Add(new MailAddress(toRecipients[i].EmailAdress, string.IsNullOrWhiteSpace(toRecipients[i].Name) ? toRecipients[i].EmailAdress : toRecipients[i].Name));


                if (atachments != null && atachments.Count != 0)
                    for (int i = 0; i < atachments.Count; ++i)
                    {
                        if (atachments[i] == null)
                            continue;

                        var temp = atachments[i].OpenReadStream();
                        byte[] byteArray;

                        using (MemoryStream ms = new())
                        {
                            ms.Position = 0;
                            temp.CopyTo(ms);
                            byteArray = ms.ToArray();
                        }

                        memStream.Write(byteArray, 0, byteArray.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                        message.Attachments.Add(new Attachment(memStream, atachments[i].ContentType));
                    }

                return message;
            }
            catch (Exception ex)
            {
                throw new Exception($"CreateEmail error: {ex.Message}", ex);
            }
        }

        public static void AddAlternateFooterImage(AlternateView alternate, IEmailSchemaModel emailSchema)
        {
            if (emailSchema.EmailFooter != null && emailSchema.EmailFooter.Id > 0)
            {
                byte[] fileByteArray = System.Convert.FromBase64String(emailSchema.EmailFooter.Logo.FileBase64String);
                using MemoryStream fs = new(fileByteArray);
                LinkedResource footer = new(fs, $"image/{emailSchema.EmailFooter.Logo.Type}")
                {
                    ContentId = "Footer"
                };
                alternate.LinkedResources.Add(footer);
            }
        }

        public static void AddFooterToBody(IEmailSchemaModel emailSchema)
        {
            emailSchema.Body = string.Format("<html>" +
                "<body>" +
                "<br />" +
                "{0}" +
                "<br />" +
                "<img src=\"cid:Footer\" />" +
                "{1}" +
                "</body>" +
                "</html>", emailSchema.Body, emailSchema.EmailFooter.TextHtml);
        }
    }
}
