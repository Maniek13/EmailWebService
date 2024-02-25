using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmailRecipients_ServiceId",
                table: "EmailRecipients",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailRecipients_ServicesPermisions_ServiceId",
                table: "EmailRecipients",
                column: "ServiceId",
                principalTable: "ServicesPermisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailRecipients_ServicesPermisions_ServiceId",
                table: "EmailRecipients");

            migrationBuilder.DropIndex(
                name: "IX_EmailRecipients_ServiceId",
                table: "EmailRecipients");
        }
    }
}
