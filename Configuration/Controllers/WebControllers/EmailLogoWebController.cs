using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;

namespace Configuration.Interfaces.WebControllers
{
    public class EmailLogoWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailLogoWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;


        public Task<IResponseModel<bool>> UpdateEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context) => throw new NotImplementedException();
    }
}
