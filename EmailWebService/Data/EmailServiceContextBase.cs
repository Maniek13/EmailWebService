using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Data
{
    public class EmailServiceContextBase : DbContext
    {
        internal string ConnectionString { get; init; }

        public EmailServiceContextBase(string connectionString) : base()
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

        public virtual DbSet<IdentityCodesDbModel> IdentityCodes { get; set; }
        public virtual DbSet<AppPermisionDbModel> AppPermisions { get; set; }
        public virtual DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings { get; set; }
        public virtual DbSet<EmailConfigurationDbModel> EmailConfigurationDb { get; set; }
        public virtual DbSet<EmailSchemaDbModel> EmailSchemas { get; set; }
        public virtual DbSet<EmailLUsersListsDbModel> ListUssers { get; set; }
    }
}
