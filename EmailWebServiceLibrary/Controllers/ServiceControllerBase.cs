using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Controllers
{
    public class ServiceControllerBase
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public ServiceControllerBase(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController = null)
        {
            _emailDbControllerRO = emailDbControllerRO;

            if (emailDbController != null)
                _emailDbController = emailDbController;
        }
    }
}
