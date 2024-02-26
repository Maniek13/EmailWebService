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

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailAccountConfigurationDbModel", b =>
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

                    b.Property<string>("SMTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("EmailAccountConfiguration");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailFooterDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmailSchemaId")
                        .HasColumnType("int");

                    b.Property<int>("LogoId")
                        .HasColumnType("int");

                    b.Property<string>("TextHtml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailSchemaId")
                        .IsUnique();

                    b.HasIndex("LogoId");

                    b.ToTable("EmailFooters");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailListRecipientDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("RecipientListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("RecipientListId");

                    b.ToTable("EmailListRecipients");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailLogoDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileByteArray")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailLogos");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", b =>
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

                    b.ToTable("EmailRecipientsLists");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipmentDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailRecipients");
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

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplyTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplyToDisplayName")
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

                    b.ToTable("EmailSchemas");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaVariablesDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmailSchemaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailSchemaId");

                    b.ToTable("EmailSchemaVariables");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", b =>
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

                    b.ToTable("ServicesPermisions");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailAccountConfigurationDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "ServicePermision")
                        .WithOne("EmailAccountConfiguration")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailAccountConfigurationDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailFooterDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "EmailSchema")
                        .WithOne("EmailFooter")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailFooterDbModel", "EmailSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailLogoDbModel", "Logo")
                        .WithMany("EmailFooter")
                        .HasForeignKey("LogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailSchema");

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailListRecipientDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailRecipmentDbModel", "Recipment")
                        .WithMany("EmailRecipients")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", "RecipientList")
                        .WithMany("Recipients")
                        .HasForeignKey("RecipientListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipientList");

                    b.Navigation("Recipment");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "ServicePermision")
                        .WithOne("EmailRecipientList")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "ServicePermision")
                        .WithOne("EmailSchema")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaVariablesDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "EmailSchema")
                        .WithMany("EmailSchemaVariables")
                        .HasForeignKey("EmailSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailSchema");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailLogoDbModel", b =>
                {
                    b.Navigation("EmailFooter");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipmentDbModel", b =>
                {
                    b.Navigation("EmailRecipients");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
                {
                    b.Navigation("EmailFooter")
                        .IsRequired();

                    b.Navigation("EmailSchemaVariables");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", b =>
                {
                    b.Navigation("EmailAccountConfiguration")
                        .IsRequired();

                    b.Navigation("EmailRecipientList")
                        .IsRequired();

                    b.Navigation("EmailSchema")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
