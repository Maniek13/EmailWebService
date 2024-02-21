using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Configuration.Interfaces.WebControllers
{


    public class EmailLogoWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailLogoWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;


        public async Task<IResponseModel<bool>> EditEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context) => throw new NotImplementedException();
        public async Task<IResponseModel<bool>> AddEmailLogoAsync(string serviceName, [FromForm] LogoWithFileModel logo, HttpContext context)
        {
            try
            {
                var file = context.Request.Form.Files[0];

                if(file == null) 
                    throw new ArgumentNullException("Prosze wybrać zdjęcie");

                LogoDbModel logoDbModel = (LogoDbModel)ConversionHelper.ConvertToLogoDbModel(logo.EmailFooterId, file, logo.Name);


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
    }
}
