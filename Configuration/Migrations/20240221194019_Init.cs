using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailFooterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileByteArray = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesPermisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesPermisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccountConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SMTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccountConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAccountConfiguration_ServicesPermisions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesPermisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyToDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailSchemas_ServicesPermisions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesPermisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipientsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipientsList_ServicesPermisions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesPermisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailSchemaVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailSchemaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSchemaVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailSchemaVariables_EmailSchemas_EmailSchemaId",
                        column: x => x.EmailSchemaId,
                        principalTable: "EmailSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailSchemaId = table.Column<int>(type: "int", nullable: false),
                    TextHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailFooterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footers_EmailSchemas_EmailSchemaId",
                        column: x => x.EmailSchemaId,
                        principalTable: "EmailSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Footers_Logos_EmailFooterId",
                        column: x => x.EmailFooterId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    RecipientListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipients_RecipientsList_RecipientListId",
                        column: x => x.RecipientListId,
                        principalTable: "RecipientsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipients_ServicesPermisions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesPermisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAccountConfiguration_ServiceId",
                table: "EmailAccountConfiguration",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSchemas_ServiceId",
                table: "EmailSchemas",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSchemaVariables_EmailSchemaId",
                table: "EmailSchemaVariables",
                column: "EmailSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Footers_EmailFooterId",
                table: "Footers",
                column: "EmailFooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Footers_EmailSchemaId",
                table: "Footers",
                column: "EmailSchemaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_RecipientListId",
                table: "Recipients",
                column: "RecipientListId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_ServiceId",
                table: "Recipients",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipientsList_ServiceId",
                table: "RecipientsList",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesPermisions_ServiceName",
                table: "ServicesPermisions",
                column: "ServiceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAccountConfiguration");

            migrationBuilder.DropTable(
                name: "EmailSchemaVariables");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "EmailSchemas");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "RecipientsList");

            migrationBuilder.DropTable(
                name: "ServicesPermisions");
        }
    }
}
