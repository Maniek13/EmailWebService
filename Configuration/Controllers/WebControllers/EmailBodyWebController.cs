using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.WebControllers
{
    public class EmailBodyWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyWebController
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
                var schemaDbModel = _emailDbControllerRO.GetEmailSchemaDbModel(permision.Id) ?? throw new Exception("Brak schematu dla danego serwisu");
                var schema = EmailConversionHelper.ConvertToEmailSchemaModel(schemaDbModel);

                var footerDb = _emailDbControllerRO.GetEmailFooter(schema.Id);
                if (footerDb != null )
                {
                    schema.EmailFooter = EmailConversionHelper.ConvertToEmailFooterModel(footerDb);

                    var logo = _emailDbControllerRO.GetEmailFooterLogo(schema.EmailFooter.EmailLogoId);
                    if (logo != null)
                        schema.EmailFooter.Logo = EmailConversionHelper.ConvertToLogoModel(logo);
                }

                var variablesDb = _emailDbControllerRO.GetVariablesList(schema.Id);
                if (schema.EmailSchemaVariables != null)
                {
                    schema.EmailSchemaVariables = [];

                    for (int i = 0; i < variablesDb.Count; ++i)
                    {
                        schema.EmailSchemaVariables.Add(EmailConversionHelper.ConvertToEmailSchemaVariablesModel(variablesDb[i]));
                    }
                }

                return new ResponseModel<EmailSchemaModel>()
                {
                    Data = schema,
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
                EmailValidationHelper.ValidateEmailSchemaModel(emailSchema);
                await _emailDbController.SetEmailBodySchemaAsync(EmailConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

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
                EmailValidationHelper.ValidateEmailSchemaModel(emailSchema);
                await _emailDbController.EditEmailBodySchemaAsync(EmailConversionHelper.ConvertToEmailSchemaDbModel(emailSchema));

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

        public async Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(string serviceName, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                await _emailDbController.DeleteEmailBodySchemaAsync(permisions.Id);

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
