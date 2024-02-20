using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Helpers
{
    internal static class ConversionHelper
    {
        public static IServicesPermisionsDbModel ConvertToAppPermisionDbModel(IServicesPermisionsDbModel appPermisionDb)
        {
            return new ServicesPermisionsDbModel()
            {
                Id = appPermisionDb.Id,
                ServiceName = appPermisionDb.ServiceName,
                EmailAccountConfiguration = appPermisionDb.EmailAccountConfiguration,
                EmailSchema = appPermisionDb.EmailSchema,
                EmailUsersLists = appPermisionDb.EmailUsersLists,
            };
        }
        public static IEmailAccountConfigurationDbModel ConvertToEmailAccountConfigurationDbModel (IEmailAccountConfigurationModel emailConfigurationModel)
        {
            return new EmailAccountConfigurationDbModel()
            {
                Id = emailConfigurationModel.Id,
                ServiceId = emailConfigurationModel.ServiceId,
                SMTP = emailConfigurationModel.SMTP,
                Port = emailConfigurationModel.Port,
                Login = emailConfigurationModel.Login,
                Password = emailConfigurationModel.Password
            };
        }
    }
}
