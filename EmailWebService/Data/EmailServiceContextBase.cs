using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Data
{
    public class EmailServiceContextBase : DbContext
    {
        internal string ConnectionString { get; init; }

        public EmailServiceContextBase(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public EmailServiceContextBase()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");
            var config = configuration.Build();


            ConnectionString = config.GetSection("AppConfig").GetSection("Connection").Value;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppPermisionDbModel>()
                .HasOne<IdentityCodeDbModel>(x => x.IdentityCode)
                .WithMany(y => y.AppPermisions)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppEmailServiceSettingsDbModel>()
                .HasOne<EmailConfigurationDbModel>(x => x.EmailConfiguration)
                .WithMany(y => y.AppEmailServiceSettings)
                .HasForeignKey(x => x.EmailConfigurationId);

            modelBuilder.Entity<IdentityCodeDbModel>()
                .HasOne<AppEmailServiceSettingsDbModel>(x => x.AppEmailServiceSettings)
                .WithOne(y => y.IdentityCode)
                .HasForeignKey<AppEmailServiceSettingsDbModel>(x => x.IdentityCodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<IdentityCodeDbModel> IdentityCodes { get; set; }
        public virtual DbSet<AppPermisionDbModel> AppPermisions { get; set; }
        public virtual DbSet<AppEmailServiceSettingsDbModel> AppEmailServiceSettings { get; set; }
        public virtual DbSet<EmailConfigurationDbModel> EmailConfigurationDb { get; set; }
        public virtual DbSet<EmailSchemaDbModel> EmailSchemas { get; set; }
        public virtual DbSet<EmailLUsersListsDbModel> ListUssers { get; set; }
    }
}
