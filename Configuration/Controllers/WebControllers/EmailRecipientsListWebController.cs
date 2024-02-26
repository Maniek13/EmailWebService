using AutoMapper;
using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;

namespace Configuration.Controllers.WebControllers
{
    public class EmailRecipientsListWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailRecipientsListWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        #region user list
        private readonly IMapper _mapper = mapper;
        public IResponseModel<EmailRecipientsListModel> GetRecipientsList(string serviceName, HttpContext context)
        {
            try
            {
                var permission = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var recipintsList = mapper.Map<EmailRecipientsListModel>(_emailDbControllerRO.GetRecipientsList(permission.Id));
                var recipientsDb = _emailDbControllerRO.GetRecipients(recipintsList.Id);
                List<EmailRecipientModel> recipients = [];


                for (int i = 0; i < recipientsDb.Count; ++i)
                {
                    recipients.Add(mapper.Map<EmailRecipientModel>(recipientsDb.ElementAt(i)));
                }
                recipintsList.Recipients = recipients;
                return new ResponseModel<EmailRecipientsListModel>()
                {
                    Data = recipintsList,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<EmailRecipientsListModel>()
                {
                    Data = null,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> AddRecipientsListAsync(string serviceName, EmailRecipientsListModel emailRecipients, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                emailRecipients.ServiceId = permision.Id;
                EmailValidationHelper.ValidateEmailRecipientsListModel(emailRecipients);
                await _emailDbController.SetRecipientsListAsync(mapper.Map<EmailRecipientsListDbModel>(emailRecipients));

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
        public async Task<IResponseModel<bool>> EditRecipientsListAsync(string serviceName, EmailRecipientsListModel emailRecipients, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                
                EmailValidationHelper.ValidateEmailRecipientsListModel(emailRecipients);
                await _emailDbController.EditRecipientsListAsync(mapper.Map<EmailRecipientsListDbModel>(emailRecipients));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int recipentListId, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");

                await _emailDbController.DeleteRecipientsListAsync(recipentListId);

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
        #endregion

        public async Task<IResponseModel<bool>> AddRecipientToLisAsync(string serviceName, int recipientsListId, int recipientId, HttpContext context)
        {
            try
            {
                if (recipientsListId == 0)
                    throw new Exception("Prosze podać nr listy do której dołączyć użytkownika do dołaczenia");
                if (recipientsListId == 0)
                    throw new Exception("Prosze podać id użytkownika");

                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.AddRecipientToLisAsync(recipientsListId, recipientId);


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
