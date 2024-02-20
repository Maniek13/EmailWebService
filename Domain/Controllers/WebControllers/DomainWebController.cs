using Domain.Interfaces.Models;
using Domain.Interfaces.WebControllers;
using Domain.Models;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrarys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Domain.Controllers.WebControllers
{
    public class DomainWebController(IEmailRODbController emailDbControllerRO) : ServiceWebControllerBase(emailDbControllerRO), IDomainWebController
    {
        readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;

        public async Task<IResponseModel<bool>> SendEmailsAsync(string serviceName, [FromForm] IFormCollection atachments, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                var cfg = _emailDbControllerRO.GetEmailAccountConfiguration(permisions.ServiceName);
                var emailSchema = _emailDbControllerRO.GetEmailSchemaDbModel(serviceName);
                var bodyschama = _emailDbControllerRO.GetEmailBodySchama(permisions.Id);

                var userList = _emailDbControllerRO.GetUsersList(permisions.Id);

                EmailModel email = new()
                {
                    Atachments = (FormFileCollection)atachments
                };

                var message = CreateEmail(email, userList, CreateBody(bodyschama), emailSchema);


                using var smtpClient = new SmtpClient(cfg.SMTP);
                smtpClient.Port = cfg.Port;
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = cfg.Login,
                    Password = cfg.Password
                };
                await smtpClient.SendMailAsync(message);


                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }

        #region helpers
        private static string CreateBody(IEmailSchemaDbModel schemaBody)
        {
            try
            {
                var variables = schemaBody.EmailSchemaVariables.ToList();


                if (variables.Count == 0)
                    return schemaBody.Body;

                if (schemaBody != null)
                {
                    string body = schemaBody.Body;

                    for (int i = 0; i < variables.Count; i++)
                    {
                        _ = body.Replace($"#{variables[i].Name}#", variables[i].Value);
                    }

                    return body;
                }

                throw new Exception("Msg don't hava a body");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static MailMessage CreateEmail(IEmailModel email, List<EmailUsersDbModel> users, string body, IEmailSchemaDbModel emailSchema)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailSchema.From))
                    throw new Exception("Please set a sender email");
                if (email.To.Count == 0)
                    throw new Exception("Please set a receiver email");

                using MailMessage message = new();
                message.Subject = emailSchema.Subject;
                message.Body = body;

                ContentType mimeType = new("text/html");
                using (AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType))
                    message.AlternateViews.Add(alternate);


                message.From = new MailAddress(emailSchema.From, string.IsNullOrWhiteSpace(emailSchema.DisplayName) ? emailSchema.From : emailSchema.DisplayName);

                if (!string.IsNullOrWhiteSpace(emailSchema.ReplyTo))
                    message.ReplyTo = new MailAddress(emailSchema.ReplyTo, string.IsNullOrWhiteSpace(emailSchema.ReplyToDisplayName) ? emailSchema.ReplyTo : emailSchema.ReplyToDisplayName);


                for (int i = 0; i < users.Count; ++i)
                {
                    message.To.Add(new MailAddress(users[i].EmailAdress, string.IsNullOrWhiteSpace(users[i].Name) ? users[i].EmailAdress : users[i].Name));
                }


                if (email.Atachments != null && email.Atachments.Count != 0)
                    for (int i = 0; i < email.Atachments.Count; ++i)
                    {
                        if (email.Atachments[i] == null)
                            continue;

                        using var memStream = new MemoryStream();
                        var temp = email.Atachments[i].OpenReadStream();
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
        #endregion
    }
}
