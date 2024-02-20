using Domain.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

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


                EmailHelper.CreateBody(bodyschama);
                var message = EmailHelper.CreateEmail(email, userList, emailSchema);


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
    }
}
