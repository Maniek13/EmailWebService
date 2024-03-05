using EmailWebServiceLibrary.Interfaces.Data;
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
               .WithOne(y => y.ServicePermision)
               .HasForeignKey<EmailAccountConfigurationDbModel>(x => x.ServiceId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicesPermisionsDbModel>()
              .HasOne<EmailSchemaDbModel>(x => x.EmailSchema)
              .WithOne(y => y.ServicePermision)
              .HasForeignKey<EmailSchemaDbModel>(x => x.ServiceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicesPermisionsDbModel>()
              .HasOne<EmailRecipientsListDbModel>(x => x.EmailRecipientList)
              .WithOne(y => y.ServicePermision)
              .HasForeignKey<EmailRecipientsListDbModel>(x => x.ServiceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailSchemaDbModel>()
              .HasOne<EmailFooterDbModel>(x => x.EmailFooter)
              .WithOne(y => y.EmailSchema)
              .HasForeignKey<EmailFooterDbModel>(x => x.EmailSchemaId)
              .OnDelete(DeleteBehavior.Cascade);

            //one to many
            modelBuilder.Entity<EmailFooterDbModel>()
              .HasOne<EmailLogoDbModel>(x => x.Logo)
              .WithMany(y => y.EmailFooter)
              .HasForeignKey(y => y.LogoId);

            modelBuilder.Entity<EmailSchemaVariablesDbModel>()
             .HasOne<EmailSchemaDbModel>(x => x.EmailSchema)
             .WithMany(y => y.EmailSchemaVariables)
             .HasForeignKey(x => x.EmailSchemaId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailListRecipientDbModel>()
             .HasOne<EmailRecipientsListDbModel>(x => x.RecipientList)
             .WithMany(y => y.Recipients)
             .HasForeignKey(x => x.RecipientListId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailListRecipientDbModel>()
              .HasOne<EmailRecipientDbModel>(x => x.Recipient)
              .WithMany(y => y.EmailRecipients)
              .HasForeignKey(y => y.RecipientId)
              .OnDelete(DeleteBehavior.Cascade);

        }
        public virtual DbSet<ServicesPermisionsDbModel> ServicesPermisions { get; set; }
        public virtual DbSet<EmailAccountConfigurationDbModel> EmailAccountConfiguration { get; set; }
        public virtual DbSet<EmailSchemaDbModel> EmailSchemas { get; set; }
        public virtual DbSet<EmailFooterDbModel> EmailFooters { get; set; }
        public virtual DbSet<EmailLogoDbModel> EmailLogos { get; set; }
        public virtual DbSet<EmailSchemaVariablesDbModel> EmailSchemaVariables { get; set; }
        public virtual DbSet<EmailRecipientsListDbModel> EmailRecipientsLists { get; set; }
        public virtual DbSet<EmailListRecipientDbModel> EmailListRecipients { get; set; }
        public virtual DbSet<EmailRecipientDbModel> EmailRecipients { get; set; }
    }
}
