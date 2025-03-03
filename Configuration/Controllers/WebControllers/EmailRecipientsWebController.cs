﻿using AutoMapper;
using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;

namespace Configuration.Controllers.WebControllers
{
    public class EmailRecipientsWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailRecipientsWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        public IResponseModel<List<EmailRecipientModel>> GetRecipients(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var recipients = _emailDbControllerRO.GetRecipients(permision.Id);
                if (recipients == null)
                    throw new Exception("Serwis nie posiada odbiorców");
                List<EmailRecipientModel> recipientsList = [];
                for (int i = 0; i < recipients.Count; ++i)
                {
                    recipientsList.Add(mapper.Map<EmailRecipientModel>(recipients[i]));
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
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.SetRecipientAsync(_mapper.Map<EmailRecipientDbModel>(recipient));

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
                EmailValidationHelper.ValidateEmailRecipientModel(recipient);
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.EditRecipientAsync(_mapper.Map<EmailRecipientDbModel>(recipient));

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
        public async Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int recipentId, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.DeleteRecipientAsync(recipentId);

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
        public IResponseModel<List<EmailRecipientModel>> GetAllRecipients(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var recipients = _emailDbControllerRO.GetRecipients();


                List<EmailRecipientModel> list = new();

                for (int i = 0; i < recipients.Count; ++i)
                {
                    list.Add(_mapper.Map<EmailRecipientModel>(recipients[i]));
                }


                return new ResponseModel<List<EmailRecipientModel>>()
                {
                    Data = list,
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
    }
}
