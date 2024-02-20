using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.WebControllers
{
    public class EmailFooterWebController(IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(emailDbControllerRO, emailDbController), IEmailFooterWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;

        public Task<IResponseModel<bool>> UpdateEmailFooterAsync(string serviceName, EmailSchemaModel emailSchema, HttpContext context) => throw new NotImplementedException();

    }
}
