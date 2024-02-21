using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class EmailFooterWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailFooterWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        public IResponseModel<List<EmailFooterModel>> GetEmailFooters(string serviceName, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                var footers = _emailDbControllerRO.GetFooters();
                List<EmailFooterModel> footersLists = [];
                for (int i = 0; i < footers.Count; ++i)
                {
                    footersLists.Add(ConversionHelper.ConvertToEmailFooterModel(footers[i]));
                }

                return new ResponseModel<List<EmailFooterModel>>()
                {
                    Data = footersLists,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailFooterModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> EditEmailFooterAsync(string serviceName, EmailFooterModel emailFooter, HttpContext context)
        {
            try
            {
                _ = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");
                _ = _emailDbController.EditEmailFooterAsync(ConversionHelper.ConvertToEmailFooterDbModel(emailFooter));

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
