using EmailWebServiceLibrary.Interfaces.DbControllers;

namespace EmailWebServiceLibrary.Controllers.WebControllers
{
    public class ServiceWebControllerBase
    {
        readonly IEmailRODbController _emailDbControllerRO;
        readonly IEmailDbController _emailDbController;

        public ServiceWebControllerBase(IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController = null)
        {
            _emailDbControllerRO = emailDbControllerRO;

            if (emailDbController != null)
                _emailDbController = emailDbController;
        }
    }
}
