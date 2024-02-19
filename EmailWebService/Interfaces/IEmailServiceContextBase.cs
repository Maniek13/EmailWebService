using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Interfaces
{
    public interface IEmailServiceContextBase
    {
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        virtual DbSet<IdentityCodeDbModel> IdentityCodes => throw new NotImplementedException();
        virtual DbSet<AppPermisionDbModel> AppPermisions => throw new NotImplementedException();
        virtual DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings => throw new NotImplementedException();
        virtual DbSet<EmailConfigurationDbModel> EmailConfiguration => throw new NotImplementedException();
        virtual DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual DbSet<EmailUsersListsDbModel> ListUssers => throw new NotImplementedException();
    }
}
