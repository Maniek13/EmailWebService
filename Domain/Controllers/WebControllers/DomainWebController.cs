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
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var emailSchema = ConversionHelper.ConvertToEmailSchemaModel(_emailDbControllerRO.GetEmailSchemaDbModel(permisions.Id));
                var configuration = ConversionHelper.ConvertToEmailAccountConfigurationModel(_emailDbControllerRO.GetEmailAccountConfiguration(permisions.Id));
                var recipments = _emailDbControllerRO.GetRecipients(permisions.Id);

                List<IEmailRecipientModel> users = [];

                for (int i = 0; i < recipments.Count; i++)
                {
                    users.Add(ConversionHelper.ConvertToEmailRecipientsModel(recipments[i]));
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
