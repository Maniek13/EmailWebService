using EmailWebServiceLibrary.Interfaces.Data;
using EmailWebServiceLibrary.Interfaces.DbModels;
using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Data
{
    public class EmailServiceContextBase : DbContext, IEmailServiceContextBase
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

            modelBuilder.Entity<ServicesPermisionsDbModel>().HasIndex(u => u.ServiceName).IsUnique();

            modelBuilder.Entity<ServicesPermisionsDbModel>()
               .HasOne<EmailAccountConfigurationDbModel>(x => x.EmailAccountConfiguration)
               .WithOne(y => y.AppPermision)
               .HasForeignKey<EmailAccountConfigurationDbModel>(x => x.ServiceId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicesPermisionsDbModel>()
              .HasOne<EmailSchemaDbModel>(x => x.EmailSchema)
              .WithOne(y => y.AppPermision)
              .HasForeignKey<EmailSchemaDbModel>(x => x.ServiceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicesPermisionsDbModel>()
              .HasOne<EmailUsersListDbModel>(x => x.EmailUsersLists)
              .WithOne(y => y.AppPermision)
              .HasForeignKey<EmailUsersListDbModel>(x => x.ServiceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailSchemaVariablesDbModel>()
             .HasOne<EmailSchemaDbModel>(x => x.EmailSchema)
             .WithMany(y => y.EmailSchemaVariables)
             .HasForeignKey(x => x.Id)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailUsersDbModel>()
             .HasOne<EmailUsersListDbModel>(x => x.UsersList)
             .WithMany(y => y.Users)
             .HasForeignKey(x => x.Id)
             .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<ServicesPermisionsDbModel> ServicesPermisions { get; set; }
        public virtual DbSet<EmailAccountConfigurationDbModel> EmailAccountConfiguration { get; set; }
        public virtual DbSet<EmailSchemaDbModel> EmailSchemas { get; set; }
        public virtual DbSet<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
        public virtual DbSet<EmailUsersDbModel> ListUssers { get; set; }
        public virtual DbSet<EmailUsersListDbModel> Ussers { get; set; }
    }
}
