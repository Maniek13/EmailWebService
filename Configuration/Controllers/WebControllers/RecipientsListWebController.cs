﻿using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class RecipientsListWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IRecipientsListWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        #region user list
        [Authorize]
        public IResponseModel<List<EmailRecipientsListModel>> GetRecipientsLists(string serviceName, HttpContext context)
        {
            try
            {
                var permission = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                var recipientsDbLists = _emailDbControllerRO.GetRecipientsLists(permission.Id);


                List<EmailRecipientsListModel> recipientsLists = [];
                for (int i = 0; i < recipientsDbLists.Count; ++i)
                {
                    recipientsLists.Add(ConversionHelper.ConvertToEmailRecipientsListModel(recipientsDbLists[i]));
                }

                return new ResponseModel<List<EmailRecipientsListModel>>()
                {
                    Data = recipientsLists,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailRecipientsListModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        [Authorize]
        public async Task<IResponseModel<bool>> AddRecipientsListAsync(string serviceName, EmailRecipientsListModel emailRecipients, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                emailRecipients.ServiceId = permision.Id;

                for (int i = 0; i<emailRecipients.Recipients.Count; ++i)
                {
                    emailRecipients.Recipients[i].ServiceId = permision.Id;
                }

                await _emailDbController.SetRecipientsListAsync(ConversionHelper.ConvertToEmailRecipientsListDbModel(emailRecipients));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
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
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        [Authorize]
        public async Task<IResponseModel<bool>> EditRecipientsListAsync(string serviceName, EmailRecipientsListModel emailRecipients, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                await _emailDbController.EditRecipientsListAsync(ConversionHelper.ConvertToEmailRecipientsListDbModel(emailRecipients));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
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
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        [Authorize]
        public async Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int id, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                await _emailDbController.DeleteRecipientsListAsync(id);

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
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
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        #endregion
    }
}
