using Domain.Interfaces;
using Domain.Models;
using EmailWebServiceLibrarys.Controllers;
using EmailWebServiceLibrarys.Interfaces;
using EmailWebServiceLibrarys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Domain.Controllers
{
    public class DomainController : ServiceControllerBase, IDomainController
    {
        IEmailDbROController _emailDbControllerRO;

        public DomainController(IEmailDbROController emailDbControllerRO) : base(emailDbControllerRO)
        {
            _emailDbControllerRO = emailDbControllerRO;
        }

        public async Task<IResponseModel<bool>> SendEmailAsync(string ServiceName, [FromForm] FormFileCollection Atachments, HttpContext Context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetAppPermision(ServiceName);
                if (permisions == null)
                    throw new Exception("service don't have a permision");


                var cfg = _emailDbControllerRO.GetEmailConfiguration(permisions.ServiceName);
                var bodyschama = _emailDbControllerRO.GetEmailBodySchama(permisions.Id);

                var userList = _emailDbControllerRO.GetUsersList(permisions.Id);

                EmailModel email = new()
                {
                    Atachments = (FormFileCollection)Context.Request.Form.Files
                };



                var message = createEmail(email, userList, createBody(bodyschama), cfg);


                using (var smtpClient = new SmtpClient(cfg.SMTP))
                {
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
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }

        #region helpers
        private string createBody(IEmailSchemaDbModel schemaBody)
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
                        body.Replace($"#{variables[i].Name}#", variables[i].Value);
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

        private MailMessage createEmail(IEmailModel email, List<EmailUsersDbModel> users, string body, IEmailConfigurationDbModel cfg)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(cfg.From))
                    throw new Exception("Please set a sender email");
                if (email.To.Count == 0)
                    throw new Exception("Please set a receiver email");

                using (MailMessage message = new MailMessage())
                {
                    message.Subject = cfg.Subject;
                    message.Body = body;

                    ContentType mimeType = new ContentType("text/html");
                    using (AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType))
                        message.AlternateViews.Add(alternate);


                    message.From = new MailAddress(cfg.From, String.IsNullOrWhiteSpace(cfg.DisplayName) ? cfg.From : cfg.DisplayName);

                    if (!String.IsNullOrWhiteSpace(cfg.ReplyTo))
                        message.ReplyTo = new MailAddress(cfg.ReplyTo, String.IsNullOrWhiteSpace(cfg.ReplyToDisplayName) ? cfg.ReplyTo : cfg.ReplyToDisplayName);


                    for (int i = 0; i < users.Count; ++i)
                    {
                        message.To.Add(new MailAddress(users[i].EmailAdress, String.IsNullOrWhiteSpace(users[i].Name) ? users[i].EmailAdress : users[i].Name));
                    }


                    if (email.Atachments != null && email.Atachments.Count != 0)
                        for (int i = 0; i < email.Atachments.Count; ++i)
                        {
                            if (email.Atachments[i] == null)
                                continue;

                            using (var memStream = new MemoryStream())
                            {
                                var temp = email.Atachments[i].OpenReadStream();
                                byte[] byteArray;

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    temp.CopyTo(ms);
                                    byteArray = ms.ToArray();
                                }

                                memStream.Write(byteArray, 0, byteArray.Length);
                                memStream.Seek(0, SeekOrigin.Begin);
                                message.Attachments.Add(new Attachment(memStream, MediaTypeNames.Application.Octet));
                            }
                        }

                    return message;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
    }
}
