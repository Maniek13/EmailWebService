using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class EmailBodyWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        #region email body

        public IResponseModel<EmailSchemaModel> GetEmailBodySchema(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var res = ConversionHelper.ConvertToEmailSchemaModel(_emailDbControllerRO.GetEmailSchemaDbModel(permision.Id));
                res.EmailFooter = ConversionHelper.ConvertToEmailFooterModel(_emailDbControllerRO.GetEmailFooter(res.Id));
                var x = _emailDbControllerRO.GetEmailFooterLogo(res.EmailFooter.Id);
                res.EmailFooter.Logo = ConversionHelper.ConvertToLogoModel(_emailDbControllerRO.GetEmailFooterLogo(res.EmailFooter.Id));
                var variablesDb = _emailDbControllerRO.GetVariablesList(res.Id);
                res.EmailSchemaVariables = [];

                for(int i =0; i< variablesDb.Count; ++i)
                {
                    res.EmailSchemaVariables.Add(ConversionHelper.ConvertToEmailSchemaVariablesModel(variablesDb[i]));
                }

                return new ResponseModel<EmailSchemaModel>()
                {
                    Data = res,
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
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> AddEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                emailSchema.ServiceId = permisions.Id;
                await _emailDbController.SetEmailBodySchemaAsync(ConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

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

        public async Task<IResponseModel<bool>> EditEmailBodySchemaAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.EditEmailBodySchemaAsync(ConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

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

        public async Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, int id, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.DeleteEmailBodySchemaAsync(id);

                return new ResponseModel<bool>()
                {
                    Data = true,
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
                    Message = ex.Message
                };
            }
        }
        #endregion
    }
}
