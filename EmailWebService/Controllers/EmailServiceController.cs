using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, [FromForm] EmailModel email, HttpContext Context)
        {
            try
            {
                //IdentityCode = Context.Request.Headers("Authorized");

                email.Atachments = (FormFileCollection)Context.Request.Form.Files;
                var message = createEmail(email);

                var cfg = _emailDbControllerRO.GetEmailConfiguration(CheckHasPermision(IdentityCode));

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

        public async Task<IResponseModel<bool>> SetEmailBodySchemaAsync(RequestModel<EmailBodySchemaModel> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                _ = await _emailDbController.SetEmailBodySchemaAsync(ConvertToEmailSchemaDbmodel(Request.RequestBody));


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
        public async Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(RequestModel<EmailBodySchemaModel> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                _ = await _emailDbController.UpdateEmailBodySchemaAsync(ConvertToEmailSchemaDbmodel(Request.RequestBody));


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

        public IResponseModel<string> GetEmailBody(RequestModel<EmailBodySchemaModel> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);
                return new ResponseModel<string>()
                {
                    Data = _emailDbControllerRO.GetEmailBody(Request.RequestBody.TemplateName, Request.RequestBody.VariablesList),
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
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> SeUsersListSchemaAsync(RequestModel<UsersListModel> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                _ = await _emailDbController.SetUserListAsync(ConvertToUsersListDbmodel(Request.RequestBody));


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
        public async Task<IResponseModel<bool>> UpdateUsersListAsync(RequestModel<UsersListModel> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                _ = await _emailDbController.UpdateUserListAsync(ConvertToUsersListDbmodel(Request.RequestBody));


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

        public IResponseModel<List<UsersListModel>> GetUsersLists(RequestModel<string> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                var list = _emailDbControllerRO.GetUsersList(Request.RequestBody);
                List<UsersListModel> returnedList = new List<UsersListModel>();

                for(int i = 0; i < list.Count; ++i)
                {
                    returnedList.Add(ConvertToUsersListModel(list[i]));
                }

                return new ResponseModel<List<UsersListModel>>()
                {
                    Data = returnedList,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<List<UsersListModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public IResponseModel<List<EmailBodySchemaModel>> GetEmailBodySchamas(RequestModel<int> Request, HttpContext Context)
        {
            try
            {
                _ = CheckHasPermision(Request.IdentityCode);

                var list = _emailDbControllerRO.GetEmailBodySchamas();
                List<EmailBodySchemaModel> returnedList = new List<EmailBodySchemaModel>();

                for (int i = 0; i < list.Count; ++i)
                {
                    returnedList.Add(ConvertToEmailBodySchemaModel(list[i]));
                }

                return new ResponseModel<List<EmailBodySchemaModel>>()
                {
                    Data = returnedList,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailBodySchemaModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        private MailMessage createEmail(IEmailModel email)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(email.From))
                    throw new Exception("Please set a sender email");
                if (email.To.Count == 0)
                    throw new Exception("Please set a receiver email");

                using (MailMessage message = new MailMessage())
                {
                    message.Subject = email.Subject;
                    message.Body = email.Body;

                    ContentType mimeType = new ContentType("text/html");
                    using (AlternateView alternate = AlternateView.CreateAlternateViewFromString(email.Body, mimeType))
                        message.AlternateViews.Add(alternate);


                    message.From = new MailAddress(email.From, String.IsNullOrWhiteSpace(email.DisplayName) ? email.From : email.DisplayName);

                    if (!String.IsNullOrWhiteSpace(email.ReplyTo))
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
    }
}
