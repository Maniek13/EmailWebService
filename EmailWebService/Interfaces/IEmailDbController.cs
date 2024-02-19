using EmailWebService.Models;

namespace EmailWebService.Interfaces
{
    public interface IEmailDbController
    {
        Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema);
        Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema);
        Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel Configuration);

        Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel Configuration);
    }
}
