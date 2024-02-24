using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.WebControllers
{
    public class EmailFooterWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : EmailServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailFooterWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;

        public async Task<IResponseModel<bool>> EditEmailFooterAsync(string serviceName, EmailFooterModel emailFooter, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                _ = _emailDbController.EditEmailFooterAsync(EmailConversionHelper.ConvertToEmailFooterDbModel(emailFooter));

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
