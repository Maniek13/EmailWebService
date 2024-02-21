using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class RecipientsWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IRecipientsWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;

        public IResponseModel<List<EmailRecipientModel>> GetRecipients(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                var recipients = _emailDbControllerRO.GetRecipients(permision.Id);

                List<EmailRecipientModel> logosList = [];
                for (int i = 0; i < recipients.Count; ++i)
                {
                    logosList.Add(ConversionHelper.ConvertToEmailRecipientsModel(recipients[i]));
                }

                return new ResponseModel<List<EmailRecipientModel>>()
                {
                    Data = logosList,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailRecipientModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                _ = await _emailDbController.SetRecipientAsync(ConversionHelper.ConvertToEmailRecipientsDbModel(recipient));

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
        public async Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                _ = await _emailDbController.EditRecipientAsync(ConversionHelper.ConvertToEmailRecipientsDbModel(recipient));

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
        public async Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int id, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                _ = await _emailDbController.DeleteRecipientAsync(id);

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
