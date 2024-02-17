using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Interfaces
{
    public interface IEmailServiceContextBase
    {
        virtual public DbSet<IdentityCodeDbModel> IdentityCodes => throw new NotImplementedException();
        virtual public DbSet<AppPermisionDbModel> AppPermisions => throw new NotImplementedException();
        virtual public DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings => throw new NotImplementedException();
        virtual public DbSet<EmailConfigurationDbModel> EmailConfiguration => throw new NotImplementedException();
        virtual public DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual public DbSet<EmailLUsersListsDbModel> ListUssers => throw new NotImplementedException();
    }
}
