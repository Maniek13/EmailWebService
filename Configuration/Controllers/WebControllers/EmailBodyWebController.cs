using AutoMapper;
using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrary.Models.Models;

namespace Configuration.Controllers.WebControllers
{
    public class EmailBodyWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        private readonly IMapper _mapper = mapper;
        readonly ILogger _logger = logger;
        #region email body

        public IResponseModel<EmailSchemaModel> GetEmailBodySchema(string serviceName, HttpContext context)
        {
            try
            {
                var permision = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var schemaDbModel = _emailDbControllerRO.GetEmailSchemaDbModel(permision.Id) ?? throw new Exception("Brak schematu dla danego serwisu");

                var schema = mapper.Map<EmailSchemaModel>(schemaDbModel);

                var footerDb = _emailDbControllerRO.GetEmailFooter(schema.Id);
                if (footerDb != null )
                {

                    schema.EmailFooter = mapper.Map<EmailFooterModel>(footerDb);

                    var logo = _emailDbControllerRO.GetEmailFooterLogo(schema.EmailFooter.EmailLogoId);
                    if (logo != null)
                        schema.EmailFooter.Logo = mapper.Map<EmailLogoModel>(logo);
                }

                var variablesDb = _emailDbControllerRO.GetVariablesList(schema.Id);
                if (schema.EmailSchemaVariables != null)
                {
                    schema.EmailSchemaVariables = [];

                    for (int i = 0; i < variablesDb.Count; ++i)
                    {
                        schema.EmailSchemaVariables.Add(mapper.Map<EmailSchemaVariablesModel>(variablesDb[i]));
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
                await _emailDbController.SetEmailBodySchemaAsync(mapper.Map<EmailSchemaDbModel>(emailSchema));

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
                await _emailDbController.EditEmailBodySchemaAsync((mapper.Map<EmailSchemaDbModel>(emailSchema)));

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
