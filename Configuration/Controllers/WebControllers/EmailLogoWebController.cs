using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;

namespace Configuration.Interfaces.WebControllers
{
    public class EmailLogoWebController(IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(emailDbControllerRO, emailDbController), IEmailLogoWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;


        public Task<IResponseModel<bool>> UpdateEmailLogoAsync(string serviceName, LogoModel logo, HttpContext context) => throw new NotImplementedException();
    }
}
