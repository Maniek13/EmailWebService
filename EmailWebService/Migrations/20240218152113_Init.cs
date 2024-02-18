using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailWebService.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variables = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListUssers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsserList = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListUssers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppEmailServiceSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityCodeId = table.Column<int>(type: "int", nullable: false),
                    EmailConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEmailServiceSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEmailServiceSettings_EmailConfiguration_EmailConfigurationId",
                        column: x => x.EmailConfigurationId,
                        principalTable: "EmailConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppEmailServiceSettings_IdentityCodes_IdentityCodeId",
                        column: x => x.IdentityCodeId,
                        principalTable: "IdentityCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPermisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityCodeId = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPermisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPermisions_IdentityCodes_IdentityCodeId",
                        column: x => x.IdentityCodeId,
                        principalTable: "IdentityCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppEmailServiceSettings_EmailConfigurationId",
                table: "AppEmailServiceSettings",
                column: "EmailConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmailServiceSettings_IdentityCodeId",
                table: "AppEmailServiceSettings",
                column: "IdentityCodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPermisions_IdentityCodeId",
                table: "AppPermisions",
                column: "IdentityCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppEmailServiceSettings");

            migrationBuilder.DropTable(
                name: "AppPermisions");

            migrationBuilder.DropTable(
                name: "EmailSchemas");

            migrationBuilder.DropTable(
                name: "ListUssers");

            migrationBuilder.DropTable(
                name: "EmailConfiguration");

            migrationBuilder.DropTable(
                name: "IdentityCodes");
        }
    }
}
