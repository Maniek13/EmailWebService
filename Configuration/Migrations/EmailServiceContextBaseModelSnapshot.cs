﻿// <auto-generated />
using Configuration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Configuration.Migrations
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

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.AppPermisionDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceName")
                        .IsUnique();

                    b.ToTable("AppPermisions");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailConfigurationDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("ReplyTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplyToDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("EmailConfiguration");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("EmailSchemas");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaVariablesDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailSchemaVariables");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailUsersDbModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserListId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListUssers");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailUsersListDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("Ussers");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailConfigurationDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.AppPermisionDbModel", "AppPermision")
                        .WithOne("EmailConfiguration")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailConfigurationDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.AppPermisionDbModel", "AppPermision")
                        .WithOne("EmailSchema")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaVariablesDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "EmailSchema")
                        .WithMany("EmailSchemaVariables")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailSchema");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailUsersDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailUsersListDbModel", "UsersList")
                        .WithMany("Users")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersList");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailUsersListDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.AppPermisionDbModel", "AppPermision")
                        .WithOne("EmailUsersLists")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailUsersListDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.AppPermisionDbModel", b =>
                {
                    b.Navigation("EmailConfiguration")
                        .IsRequired();

                    b.Navigation("EmailSchema")
                        .IsRequired();

                    b.Navigation("EmailUsersLists")
                        .IsRequired();
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
                {
                    b.Navigation("EmailSchemaVariables");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailUsersListDbModel", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
