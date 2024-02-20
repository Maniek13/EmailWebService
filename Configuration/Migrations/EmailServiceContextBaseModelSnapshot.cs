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

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.EmailAccountConfigurationDbModel", b =>
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

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.EmailFooterDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmailFooterId")
                        .HasColumnType("int");

                    b.Property<int>("EmailSchemaId")
                        .HasColumnType("int");

                    b.Property<string>("TextHtml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailFooterId");

                    b.HasIndex("EmailSchemaId")
                        .IsUnique();

                    b.ToTable("EmailFooters");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.LogoDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmailFooterId")
                        .HasColumnType("int");

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

                    b.ToTable("Logos");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsDbModel", b =>
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

                    b.Property<int>("RecipientListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientListId");

                    b.ToTable("ListUssers");
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

                    b.ToTable("Ussers");
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

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.EmailAccountConfigurationDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "AppPermision")
                        .WithOne("EmailAccountConfiguration")
                        .HasForeignKey("EmailWebServiceLibrary.Interfaces.DbModels.EmailAccountConfigurationDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.EmailFooterDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Interfaces.DbModels.LogoDbModel", "Logo")
                        .WithMany("EmailFooter")
                        .HasForeignKey("EmailFooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", "EmailSchema")
                        .WithOne("EmailFooter")
                        .HasForeignKey("EmailWebServiceLibrary.Interfaces.DbModels.EmailFooterDbModel", "EmailSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailSchema");

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", "RecipientList")
                        .WithMany("Recipients")
                        .HasForeignKey("RecipientListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipientList");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "AppPermision")
                        .WithOne("EmailRecipientList")
                        .HasForeignKey("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermision");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailSchemaDbModel", b =>
                {
                    b.HasOne("EmailWebServiceLibrary.Models.DbModels.ServicesPermisionsDbModel", "AppPermision")
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
                        .HasForeignKey("EmailSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailSchema");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Interfaces.DbModels.LogoDbModel", b =>
                {
                    b.Navigation("EmailFooter");
                });

            modelBuilder.Entity("EmailWebServiceLibrary.Models.DbModels.EmailRecipientsListDbModel", b =>
                {
                    b.Navigation("Recipients");
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
