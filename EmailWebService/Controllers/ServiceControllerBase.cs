using EmailWebService.Interfaces;
using EmailWebService.Models;
using System.ComponentModel;

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

        #region helper functions
        [Description("Return IdentityCodeId")]
        internal int CheckHasPermision(string IdentityCode)
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
        private IAppPermisionModel GetAppPermision(int IdentityCodeId)
        {
            try
            {
                return ConvertToAppPermisoin(_emailDbControllerRO.GetAppPermision(IdentityCodeId, AppConfig.ServiceName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        internal IEmailConfigurationModel ConvertToEmailConfiguration(IEmailConfigurationDbModel email)
        {
            return new EmailConfigurationModel
            {
                Id = email.Id,
                ProviderName = email.ProviderName,
                SMTP = email.SMTP,
                Port = email.Port,
                Login = email.Login,
                Password = email.Password,
            };
        }

        internal IAppPermisionModel ConvertToAppPermisoin(IAppPermisionDbModel email)
        {
            return new AppPermisionModel
            {
                Id = email.Id,
                IdentityCodeId = email.IdentityCodeId,
                ServiceName = email.ServiceName,
            };
        }
        #endregion
    }
}
