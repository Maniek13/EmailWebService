using Domain.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Domain.Controllers.WebControllers
{
    public class DomainWebController(ILogger logger, IEmailRODbController emailDbControllerRO) : ServiceWebControllerBase(logger, emailDbControllerRO), IDomainWebController
    {
        readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly ILogger _logger = logger;

        public async Task<IResponseModel<bool>> SendEmailsAsync(string serviceName, [FromForm] IFormFileCollection atachments, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                var emailSchema = ConversionHelper.ConvertToEmailSchemaModel(_emailDbControllerRO.GetEmailSchemaDbModel(serviceName));
                var configuration = ConversionHelper.ConvertToEmailAccountConfigurationModel(_emailDbControllerRO.GetEmailAccountConfiguration(permisions.ServiceName));


                var userList = _emailDbControllerRO.GetUsersList(permisions.Id);



                List<IEmailRecipientModel> users = new();


                for (int i = 0; i < userList.Count; i++)
                {
                    users.Add(ConversionHelper.ConvertToEmailUserModel(userList[i]));
                }

                await EmailHelper.SendEmail(emailSchema, users, configuration, atachments);


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
