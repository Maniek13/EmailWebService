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
                _ = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                var recipients = _emailDbControllerRO.GetRecipients();

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
        public Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel user, HttpContext context) => throw new NotImplementedException();
        public Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel user, HttpContext context) => throw new NotImplementedException();
        public Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int id, HttpContext context) => throw new NotImplementedException();

    }
}
