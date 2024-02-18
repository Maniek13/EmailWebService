using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Interfaces
{
    public interface IEmailServiceContextBase
    {
        virtual DbSet<IdentityCodeDbModel> IdentityCodes => throw new NotImplementedException();
        virtual DbSet<AppPermisionDbModel> AppPermisions => throw new NotImplementedException();
        virtual DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings => throw new NotImplementedException();
        virtual DbSet<EmailConfigurationDbModel> EmailConfiguration => throw new NotImplementedException();
        virtual DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual DbSet<EmailLUsersListsDbModel> ListUssers => throw new NotImplementedException();
    }
}
