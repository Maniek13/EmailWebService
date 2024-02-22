using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class EmailBodyWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        #region email body
        [Authorize()]
        public IResponseModel<EmailSchemaModel> GetEmailBodySchema(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                return new ResponseModel<EmailSchemaModel>()
                {
                    Data = ConversionHelper.ConvertToEmailSchemaModel(_emailDbControllerRO.GetEmailSchemaDbModel(permision.Id)),
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<EmailSchemaModel>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        [Authorize]
        public async Task<IResponseModel<bool>> AddEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                emailSchema.ServiceId = permisions.Id;
                await _emailDbController.SetEmailBodySchemaAsync(ConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)400,
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
        public async Task<IResponseModel<bool>> EditEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                await _emailDbController.EditEmailBodySchemaAsync(ConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)400,
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
        [Authorize()]
        public async Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, int id, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                await _emailDbController.DeleteEmailBodySchemaAsync(id);

                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)400,
                    Message = "ok"
                };

                throw new NotImplementedException();
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
