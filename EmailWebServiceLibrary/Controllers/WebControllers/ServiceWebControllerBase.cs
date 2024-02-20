using EmailWebServiceLibrary.Interfaces.DbControllers;
using Microsoft.Extensions.Logging;

namespace EmailWebServiceLibrary.Controllers.WebControllers
{
    public class ServiceWebControllerBase
    {
        readonly IEmailRODbController _emailDbControllerRO;
        readonly IEmailDbController _emailDbController;
        readonly ILogger _logger;

        public ServiceWebControllerBase(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController = null)
        {
            _logger = logger;
            _emailDbControllerRO = emailDbControllerRO;

            if (emailDbController != null)
                _emailDbController = emailDbController;
        }
    }
}
