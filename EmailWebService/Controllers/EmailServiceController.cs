using Azure;
using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace EmailWebService.Controllers
{
    public class EmailServiceController : ServiceControllerBase, IEmailServiceController
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailServiceController(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController) : base(emailDbControllerRO, emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }

        public async Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, EmailModel email, HttpContext Context)
        {
            try
            {
                var message = createEmail(email);

                var cfg = _emailDbControllerRO.GetEmailConfiguration(CheckHasPermision(IdentityCode));

                using(var smtpClient = new SmtpClient(cfg.SMTP))
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

        public async Task<IResponseModel<bool>> SetEmailBodyAsync(string IdentityCode, string SchemaName, string Body, List<(string Name, string Value)> VariablesList, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(IdentityCode);

                _ = await _emailDbController.SetEmailBodyAsync(SchemaName, SchemaName, VariablesList);
               
              
                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
                
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
        public async Task<IResponseModel<bool>> UpdateEmailBodyAsync(string IdentityCode, string SchemaName, string Body, List<(string Name, string Value)> VariablesList, HttpContext Context)
        {
            try
            {
                throw new NotImplementedException();
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

        public IResponseModel<string> GetEmailBody(string IdentityCode, string SchemaName, List<(string Name, string Value)> VariablesList, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(IdentityCode);
                return new ResponseModel<string>()
                {
                    Data = _emailDbControllerRO.GetEmailBody(SchemaName, VariablesList),
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<string>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)200,
                    Message = ex.Message
                };
            }
        }

        private MailMessage createEmail(IEmailModel email)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.Subject = email.Subject;
                    message.Body = email.Body;

                    ContentType mimeType = new ContentType("text/html");
                    using (AlternateView alternate = AlternateView.CreateAlternateViewFromString(email.Body, mimeType))
                        message.AlternateViews.Add(alternate);

                    message.From = new MailAddress(email.From, String.IsNullOrWhiteSpace(email.DisplayName) ? email.From : email.DisplayName);
                    message.ReplyTo = new MailAddress(email.ReplyTo, String.IsNullOrWhiteSpace(email.ReplyToName) ? email.ReplyTo : email.ReplyToName);

                    for (int i = 0; i < email.To.Count; ++i)
                    {
                        message.To.Add(new MailAddress(email.To[i], email.To[i]));
                    }

                    for (int i = 0; i < email.Cc.Count; ++i)
                    {
                        message.CC.Add(new MailAddress(email.To[i], email.To[i]));
                    }

                    for (int i = 0; i < email.Bcc.Count; ++i)
                    {
                        message.Bcc.Add(new MailAddress(email.To[i], email.To[i]));
                    }

                    if (email.Atachments != null && email.Atachments.Count != 0)
                        for (int i = 0; i < email.Atachments.Count; ++i)
                        {
                            if (email.Atachments[i].File.IsNullOrEmpty() || email.Atachments[i].Name.IsNullOrEmpty())
                                continue;

                            using (var memStream = new MemoryStream())
                            {
                                memStream.Write(email.Atachments[i].File, 0, email.Atachments[i].File.Length);
                                memStream.Seek(0, SeekOrigin.Begin);
                                message.Attachments.Add(new Attachment(memStream, MediaTypeNames.Application.Octet));
                            }
                        }

                    return message;
                }

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
