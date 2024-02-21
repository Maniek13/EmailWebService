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
        virtual DbSet<EmailRecipientsDbModel> Recipients => throw new NotImplementedException();
        virtual DbSet<EmailRecipientsListDbModel> RecipientsList => throw new NotImplementedException();
    }
}
