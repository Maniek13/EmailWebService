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
    public class EmailBodyVariablesWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyVariablesWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IResponseModel<bool>> EditBodySchemaVariablesAsync(string serviceName, EmailSchemaVariablesModel variables, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                EmailValidationHelper.ValidateEmailSchemaVariablesModel(variables);
                await _emailDbController.EditBodyVariablesAsync(_mapper.Map<EmailSchemaVariablesDbModel>(variables));

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
