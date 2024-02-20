﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailFooterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileByteArray = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_EmailFooters_EmailSchemaId",
                table: "EmailFooters",
                column: "EmailSchemaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logos_EmailFooterId",
                table: "Logos",
                column: "EmailFooterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "EmailFooters");
        }
    }
}
