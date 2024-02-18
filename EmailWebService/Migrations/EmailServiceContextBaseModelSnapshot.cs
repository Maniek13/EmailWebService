﻿// <auto-generated />
using EmailWebService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmailWebService.Migrations
{
    [DbContext(typeof(EmailServiceContextBase))]
    partial class EmailServiceContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmailWebService.Models.AppEmailServiceSettingsDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmailConfigurationId")
                        .HasColumnType("int");

                    b.Property<int>("IdentityCodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmailConfigurationId");

                    b.HasIndex("IdentityCodeId")
                        .IsUnique();

                    b.ToTable("AppEmailServiceSettings");
                });

            modelBuilder.Entity("EmailWebService.Models.AppPermisionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdentityCodeId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityCodeId");

                    b.ToTable("AppPermisions");
                });

            modelBuilder.Entity("EmailWebService.Models.EmailConfigurationDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailConfiguration");
                });

            modelBuilder.Entity("EmailWebService.Models.EmailLUsersListsDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsserList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListUssers");
                });

            modelBuilder.Entity("EmailWebService.Models.EmailSchemaDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Variables")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EmailSchemas");
                });

            modelBuilder.Entity("EmailWebService.Models.IdentityCodeDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityCodes");
                });

            modelBuilder.Entity("EmailWebService.Models.AppEmailServiceSettingsDbModel", b =>
                {
                    b.HasOne("EmailWebService.Models.EmailConfigurationDbModel", "EmailConfiguration")
                        .WithMany("AppEmailServiceSettings")
                        .HasForeignKey("EmailConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmailWebService.Models.IdentityCodeDbModel", "IdentityCode")
                        .WithOne("AppEmailServiceSettings")
                        .HasForeignKey("EmailWebService.Models.AppEmailServiceSettingsDbModel", "IdentityCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailConfiguration");

                    b.Navigation("IdentityCode");
                });

            modelBuilder.Entity("EmailWebService.Models.AppPermisionDbModel", b =>
                {
                    b.HasOne("EmailWebService.Models.IdentityCodeDbModel", "IdentityCode")
                        .WithMany("AppPermisions")
                        .HasForeignKey("IdentityCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityCode");
                });

            modelBuilder.Entity("EmailWebService.Models.EmailConfigurationDbModel", b =>
                {
                    b.Navigation("AppEmailServiceSettings");
                });

            modelBuilder.Entity("EmailWebService.Models.IdentityCodeDbModel", b =>
                {
                    b.Navigation("AppEmailServiceSettings")
                        .IsRequired();

                    b.Navigation("AppPermisions");
                });
#pragma warning restore 612, 618
        }
    }
}
