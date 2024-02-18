using EmailWebService.Interfaces;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class ServiceControllerBase
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public ServiceControllerBase(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }

        internal int GetIdentityCodeId(string IdentityCode)
        {
            try
            {
                int identityCodeId = _emailDbControllerRO.GetIdentityCodeId(IdentityCode);

                var permision = GetAppPermision(identityCodeId);
                if (permision != null)
                    return permision.IdentityCodeId;
  
                throw new Exception("App don't have permision to use email service\"");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        internal IAppPermisionModel GetAppPermision(int IdentityCodeId)
        {
            try
            {
                return _emailDbControllerRO.GetAppPermision(IdentityCodeId, AppConfig.ServiceName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
