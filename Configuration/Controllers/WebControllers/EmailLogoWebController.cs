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


        public IResponseModel<List<LogoModel>> GetEmailLogos(string serviceName, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                var logos = _emailDbControllerRO.GetLogos();

                List<LogoModel> logosList = [];
                for (int i = 0; i < logos.Count; ++i)
                {
                    logosList.Add(ConversionHelper.ConvertToLogoModel(logos[i]));
                }

                return new ResponseModel<List<LogoModel>>()
                {
                    Data = logosList,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<List<LogoModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
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
