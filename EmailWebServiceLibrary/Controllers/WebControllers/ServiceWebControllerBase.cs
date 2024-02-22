using EmailWebServiceLibrary.Interfaces.DbControllers;
using Microsoft.Extensions.Logging;

namespace EmailWebServiceLibrary.Controllers.WebControllers
{
    public class ServiceWebControllerBase(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController = null)
    {
    }
}
