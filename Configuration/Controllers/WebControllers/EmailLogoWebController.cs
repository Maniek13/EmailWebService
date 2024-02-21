using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.Models;
using System.Net;

namespace Configuration.Interfaces.WebControllers
{


    public class EmailLogoWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailLogoWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;


        public async Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("service don't have a permision");
                _ = await _emailDbController.EditLogoAsync(ConversionHelper.ConvertToLogoDbModel(logo));

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
    }
}
