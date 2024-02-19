using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EmailWebServiceLibrary.Interfaces.Data
{
    public interface IEmailServiceContextBase
    {
        virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        virtual DbSet<AppPermisionDbModel> AppPermisions => throw new NotImplementedException();
        virtual DbSet<EmailConfigurationDbModel> EmailConfiguration => throw new NotImplementedException();
        virtual DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual DbSet<EmailSchemaVariablesDbModel> EmailSchemaVariables => throw new NotImplementedException();
        virtual DbSet<EmailUsersDbModel> ListUssers => throw new NotImplementedException();
        virtual DbSet<EmailUsersListDbModel> Ussers => throw new NotImplementedException();
    }
}
