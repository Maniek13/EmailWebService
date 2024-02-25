using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailRecipients_EmailRecipientsLists_RecipientListId",
                table: "EmailRecipients");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailRecipients_UserDbModel_UsersId",
                table: "EmailRecipients");

            migrationBuilder.DropTable(
                name: "UserDbModel");

            migrationBuilder.DropIndex(
                name: "IX_EmailRecipients_RecipientListId",
                table: "EmailRecipients");

            migrationBuilder.DropIndex(
                name: "IX_EmailRecipients_UsersId",
                table: "EmailRecipients");

            migrationBuilder.DropColumn(
                name: "RecipientListId",
                table: "EmailRecipients");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "EmailRecipients");

            migrationBuilder.CreateTable(
                name: "EmailListRecipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientListId = table.Column<int>(type: "int", nullable: false),
                    RecipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailListRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailListRecipients_EmailRecipientsLists_RecipientListId",
                        column: x => x.RecipientListId,
                        principalTable: "EmailRecipientsLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmailListRecipients_EmailRecipients_RecipmentId",
                        column: x => x.RecipmentId,
                        principalTable: "EmailRecipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailListRecipients_RecipientListId",
                table: "EmailListRecipients",
                column: "RecipientListId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailListRecipients_RecipmentId",
                table: "EmailListRecipients",
                column: "RecipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailListRecipients");

            migrationBuilder.AddColumn<int>(
                name: "RecipientListId",
                table: "EmailRecipients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "EmailRecipients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDbModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailRecipients_RecipientListId",
                table: "EmailRecipients",
                column: "RecipientListId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailRecipients_UsersId",
                table: "EmailRecipients",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailRecipients_EmailRecipientsLists_RecipientListId",
                table: "EmailRecipients",
                column: "RecipientListId",
                principalTable: "EmailRecipientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailRecipients_UserDbModel_UsersId",
                table: "EmailRecipients",
                column: "UsersId",
                principalTable: "UserDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
