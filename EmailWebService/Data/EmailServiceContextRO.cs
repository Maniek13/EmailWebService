using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Data
{
    public class EmailServiceContextRO : DbContext
    {
            private string ConnectionString { get; init; }

            public EmailServiceContextRO(string connectionString) : base()
            {
                ConnectionString = connectionString;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                try
                {
                    if (!optionsBuilder.IsConfigured)
                    {
                        optionsBuilder.UseSqlServer(ConnectionString);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }


            [Obsolete("This context is read-only", true)]
            public new int SaveChanges()
            {
                throw new InvalidOperationException("This context is read-only.");
            }

            [Obsolete("This context is read-only", true)]
            public new int SaveChanges(bool acceptAll)
            {
                throw new InvalidOperationException("This context is read-only.");
            }

            [Obsolete("This context is read-only", true)]
            public new Task<int> SaveChangesAsync(CancellationToken token = default)
            {
                throw new InvalidOperationException("This context is read-only.");
            }

            [Obsolete("This context is read-only", true)]
            public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
            {
                throw new InvalidOperationException("This context is read-only.");
            }

            public virtual DbSet<IdentityCodesDbModel> IdentityCodes { get; set; }
            public virtual DbSet<AppPermisionDbModel> AppPermisions { get; set; }
            public virtual DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings { get; set; }
            public virtual DbSet<EmailConfigurationDbModel> EmailConfigurations { get; set; }
            public virtual DbSet<EmailSchemaDbModel> EmailSchemas { get; set; }
            public virtual DbSet<EmailLUsersListsDbModel> ListUssers { get; set; }
    }
}

