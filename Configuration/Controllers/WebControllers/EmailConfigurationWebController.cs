using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class EmailConfigurationWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailConfigurationWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;

        #region email config
        public IResponseModel<EmailAccountConfigurationModel> GetEmailAccountConfiguration(string serviceName, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                var configuration = ConversionHelper.ConvertToEmailAccountConfigurationModel(_emailDbControllerRO.GetEmailAccountConfiguration(permisions.Id));

                return new ResponseModel<EmailAccountConfigurationModel>()
                {
                    Data = configuration,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<EmailAccountConfigurationModel>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> SetEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                _ = await _emailDbController.SetEmailConfigurationAsync(ConversionHelper.ConvertToEmailAccountConfigurationDbModel(emailAccountConfiguration));
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

        public async Task<IResponseModel<bool>> EditEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                _ = await _emailDbController.EditEmailConfigurationAsync(ConversionHelper.ConvertToEmailAccountConfigurationDbModel(emailAccountConfiguration));
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
        public async Task<IResponseModel<bool>> DeleteEmailAccountConfigurationAsync(string serviceName, int id, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");

                _ = await _emailDbController.DeleteEmailConfigurationAsync(id);
                return new ResponseModel<bool>()
                {
                    Data = true,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
                throw new NotImplementedException();
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
        #endregion
    }
}
