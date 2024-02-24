using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.WebControllers
{
    public class EmailRecipientsWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailRecipientsWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;

        public IResponseModel<List<EmailRecipientModel>> GetRecipients(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var recipients = _emailDbControllerRO.GetRecipients(permision.Id);

                List<EmailRecipientModel> recipientsList = [];
                for (int i = 0; i < recipients.Count; ++i)
                {
                    recipientsList.Add(EmailConversionHelper.ConvertToEmailRecipientsModel(recipients[i]));
                }

                return new ResponseModel<List<EmailRecipientModel>>()
                {
                    Data = recipientsList,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailRecipientModel>>()
                {
                    Data = null,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context)
        {
            try
            {
                if (recipient.RecipientsListId == 0)
                    throw new Exception("Odbiorca nie posiada nr listy do jakiej go dodac");
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                recipient.ServiceId = permision.Id;
                await _emailDbController.SetRecipientAsync(EmailConversionHelper.ConvertToEmailRecipientsDbModel(recipient));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.EditRecipientAsync(EmailConversionHelper.ConvertToEmailRecipientsDbModel(recipient));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int id, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.DeleteRecipientAsync(id);

                return new ResponseModel<bool>()
                {
                    Data = true,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    Message = ex.Message
                };
            }
        }

    }
}
