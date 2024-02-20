using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EmailWebServiceLibrary.Interfaces.Data
{
    public interface IEmailServiceContextBase
    {
        virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        virtual DbSet<ServicesPermisionsDbModel> AppPermisions => throw new NotImplementedException();
        virtual DbSet<EmailAccountConfigurationDbModel> EmailAccountConfiguration => throw new NotImplementedException();
        virtual DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual DbSet<EmailSchemaVariablesDbModel> EmailSchemaVariables => throw new NotImplementedException();
        virtual DbSet<EmailRecipientsDbModel> ListUssers => throw new NotImplementedException();
        virtual DbSet<EmailRecipientsListDbModel> Ussers => throw new NotImplementedException();
    }
}
