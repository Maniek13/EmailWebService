﻿using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class RecipientsListWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IRecipientsListWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        #region user list

        public IResponseModel<EmailRecipientsListModel> GetRecipientsList(string serviceName, HttpContext context)
        {
            try
            {
                var permission = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var recipintsList = ConversionHelper.ConvertToEmailRecipientsListModel(_emailDbControllerRO.GetRecipientsList(permission.Id));
                var recipientsDb = _emailDbControllerRO.GetRecipients(recipintsList.Id);
                List<EmailRecipientModel> recipients = [];


                for (int i = 0; i < recipientsDb.Count; ++i)
                {
                    recipients.Add(ConversionHelper.ConvertToEmailRecipientsModel(recipientsDb.ElementAt(i)));
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

                for (int i = 0; i < emailRecipients.Recipients.Count; ++i)
                {
                    emailRecipients.Recipients[i].ServiceId = permision.Id;
                }

                await _emailDbController.SetRecipientsListAsync(ConversionHelper.ConvertToEmailRecipientsListDbModel(emailRecipients));

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
                await _emailDbController.EditRecipientsListAsync(ConversionHelper.ConvertToEmailRecipientsListDbModel(emailRecipients));

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

        public async Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int id, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.DeleteRecipientsListAsync(id);

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
    }
}
