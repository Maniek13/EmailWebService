using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.DbModels;

namespace EmailWebServiceLibrary.Helpers
{
    internal static class ConversionHelper
    {
        public static IAppPermisionDbModel ConvertToAppPermisionDbModel(IAppPermisionDbModel appPermisionDb)
        {
            return new AppPermisionDbModel()
            {
                Id = appPermisionDb.Id,
                ServiceName = appPermisionDb.ServiceName,
                EmailConfiguration = appPermisionDb.EmailConfiguration,
                EmailSchema = appPermisionDb.EmailSchema,
                EmailUsersLists = appPermisionDb.EmailUsersLists,
            };
        }
        public static IEmailConfigurationDbModel ConvertToEmailConfigurationDbModel(IEmailConfigurationModel emailConfigurationModel)
        {
            return new EmailConfigurationDbModel()
            {
                Id = emailConfigurationModel.Id,
                Subject = emailConfigurationModel.Subject,
                From = emailConfigurationModel.From,
                ReplyTo = emailConfigurationModel.ReplyTo,
                ReplyToDisplayName = emailConfigurationModel.ReplyToDisplayName,
                DisplayName = emailConfigurationModel.DisplayName,
                ServiceId = emailConfigurationModel.ServiceId,
                SMTP = emailConfigurationModel.SMTP,
                Port = emailConfigurationModel.Port,
                Login = emailConfigurationModel.Login,
                Password = emailConfigurationModel.Password
            };
        }
    }
}
