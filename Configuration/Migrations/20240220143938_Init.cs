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
                name: "Ussers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ussers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ussers_ServicesPermisions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesPermisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailFooters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailSchemaId = table.Column<int>(type: "int", nullable: false),
                    TextHtml = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailFooters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailFooters_EmailSchemas_EmailSchemaId",
                        column: x => x.EmailSchemaId,
                        principalTable: "EmailSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailSchemaVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSchemaVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailSchemaVariables_EmailSchemas_Id",
                        column: x => x.Id,
                        principalTable: "EmailSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListUssers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserListId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListUssers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListUssers_Ussers_Id",
                        column: x => x.Id,
                        principalTable: "Ussers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Logos_EmailFooters_EmailFooterId",
                        column: x => x.EmailFooterId,
                        principalTable: "EmailFooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAccountConfiguration_ServiceId",
                table: "EmailAccountConfiguration",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailFooters_EmailSchemaId",
                table: "EmailFooters",
                column: "EmailSchemaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSchemas_ServiceId",
                table: "EmailSchemas",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logos_EmailFooterId",
                table: "Logos",
                column: "EmailFooterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesPermisions_ServiceName",
                table: "ServicesPermisions",
                column: "ServiceName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ussers_ServiceId",
                table: "Ussers",
                column: "ServiceId",
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
                name: "ListUssers");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "Ussers");

            migrationBuilder.DropTable(
                name: "EmailFooters");

            migrationBuilder.DropTable(
                name: "EmailSchemas");

            migrationBuilder.DropTable(
                name: "ServicesPermisions");
        }
    }
}
