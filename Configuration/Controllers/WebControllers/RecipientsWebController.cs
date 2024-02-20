using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Controllers.WebControllers
{
    public class RecipientsWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IRecipientsWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;


        public Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel user, HttpContext context) => throw new NotImplementedException();
        public Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel user, HttpContext context) => throw new NotImplementedException();
        public Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int id, HttpContext context) => throw new NotImplementedException();

    }
}
