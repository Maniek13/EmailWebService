using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailListRecipients_EmailRecipients_RecipmentId",
                table: "EmailListRecipients");

            migrationBuilder.RenameColumn(
                name: "RecipmentId",
                table: "EmailListRecipients",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailListRecipients_RecipmentId",
                table: "EmailListRecipients",
                newName: "IX_EmailListRecipients_RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailListRecipients_EmailRecipients_RecipientId",
                table: "EmailListRecipients",
                column: "RecipientId",
                principalTable: "EmailRecipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailListRecipients_EmailRecipients_RecipientId",
                table: "EmailListRecipients");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "EmailListRecipients",
                newName: "RecipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailListRecipients_RecipientId",
                table: "EmailListRecipients",
                newName: "IX_EmailListRecipients_RecipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailListRecipients_EmailRecipients_RecipmentId",
                table: "EmailListRecipients",
                column: "RecipmentId",
                principalTable: "EmailRecipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
