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
    public class EmailConfigurationWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailConfigurationWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        public IResponseModel<EmailAccountConfigurationModel> GetEmailAccountConfiguration(string serviceName, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var configuration = _mapper.Map<EmailAccountConfigurationModel>(_emailDbControllerRO.GetEmailAccountConfiguration(permisions.Id));
                return new ResponseModel<EmailAccountConfigurationModel>()
                {
                    Data = configuration,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType()} : {ex.Message}");
                context.Response.StatusCode = 400;
                return new ResponseModel<EmailAccountConfigurationModel>()
                {
                    Data = null,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> AddEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                EmailValidationHelper.ValidateEmailAccountConfigurationModel(emailAccountConfiguration);
                emailAccountConfiguration.ServiceId = permisions.Id;
                await _emailDbController.SetEmailConfigurationAsync(_mapper.Map<EmailAccountConfigurationDbModel>(emailAccountConfiguration));
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
        public async Task<IResponseModel<bool>> EditEmailAccountConfigurationAsync(string serviceName, EmailAccountConfigurationModel emailAccountConfiguration, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                EmailValidationHelper.ValidateEmailAccountConfigurationModel(emailAccountConfiguration);
                await _emailDbController.EditEmailConfigurationAsync(_mapper.Map<EmailAccountConfigurationDbModel>(emailAccountConfiguration));
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
        public async Task<IResponseModel<bool>> DeleteEmailAccountConfigurationAsync(string serviceName, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");

                await _emailDbController.DeleteEmailConfigurationAsync(permisions.Id);
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
    }
}
