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
                name: "FK_Footers_EmailSchemas_EmailSchemaId",
                table: "Footers");

            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Logos_LogoId",
                table: "Footers");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_RecipientsList_RecipientListId",
                table: "Recipients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipientsList_ServicesPermisions_ServiceId",
                table: "RecipientsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipientsList",
                table: "RecipientsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logos",
                table: "Logos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Footers",
                table: "Footers");

            migrationBuilder.RenameTable(
                name: "RecipientsList",
                newName: "EmailRecipientsLists");

            migrationBuilder.RenameTable(
                name: "Recipients",
                newName: "EmailRecipients");

            migrationBuilder.RenameTable(
                name: "Logos",
                newName: "EmailLogos");

            migrationBuilder.RenameTable(
                name: "Footers",
                newName: "EmailFooters");

            migrationBuilder.RenameIndex(
                name: "IX_RecipientsList_ServiceId",
                table: "EmailRecipientsLists",
                newName: "IX_EmailRecipientsLists_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_RecipientListId",
                table: "EmailRecipients",
                newName: "IX_EmailRecipients_RecipientListId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_EmailAdress",
                table: "EmailRecipients",
                newName: "IX_EmailRecipients_EmailAdress");

            migrationBuilder.RenameIndex(
                name: "IX_Footers_LogoId",
                table: "EmailFooters",
                newName: "IX_EmailFooters_LogoId");

            migrationBuilder.RenameIndex(
                name: "IX_Footers_EmailSchemaId",
                table: "EmailFooters",
                newName: "IX_EmailFooters_EmailSchemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailRecipientsLists",
                table: "EmailRecipientsLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailRecipients",
                table: "EmailRecipients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailLogos",
                table: "EmailLogos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailFooters",
                table: "EmailFooters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFooters_EmailLogos_LogoId",
                table: "EmailFooters",
                column: "LogoId",
                principalTable: "EmailLogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFooters_EmailSchemas_EmailSchemaId",
                table: "EmailFooters",
                column: "EmailSchemaId",
                principalTable: "EmailSchemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailRecipients_EmailRecipientsLists_RecipientListId",
                table: "EmailRecipients",
                column: "RecipientListId",
                principalTable: "EmailRecipientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailRecipientsLists_ServicesPermisions_ServiceId",
                table: "EmailRecipientsLists",
                column: "ServiceId",
                principalTable: "ServicesPermisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailFooters_EmailLogos_LogoId",
                table: "EmailFooters");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFooters_EmailSchemas_EmailSchemaId",
                table: "EmailFooters");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailRecipients_EmailRecipientsLists_RecipientListId",
                table: "EmailRecipients");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailRecipientsLists_ServicesPermisions_ServiceId",
                table: "EmailRecipientsLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailRecipientsLists",
                table: "EmailRecipientsLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailRecipients",
                table: "EmailRecipients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailLogos",
                table: "EmailLogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailFooters",
                table: "EmailFooters");

            migrationBuilder.RenameTable(
                name: "EmailRecipientsLists",
                newName: "RecipientsList");

            migrationBuilder.RenameTable(
                name: "EmailRecipients",
                newName: "Recipients");

            migrationBuilder.RenameTable(
                name: "EmailLogos",
                newName: "Logos");

            migrationBuilder.RenameTable(
                name: "EmailFooters",
                newName: "Footers");

            migrationBuilder.RenameIndex(
                name: "IX_EmailRecipientsLists_ServiceId",
                table: "RecipientsList",
                newName: "IX_RecipientsList_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailRecipients_RecipientListId",
                table: "Recipients",
                newName: "IX_Recipients_RecipientListId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailRecipients_EmailAdress",
                table: "Recipients",
                newName: "IX_Recipients_EmailAdress");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFooters_LogoId",
                table: "Footers",
                newName: "IX_Footers_LogoId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFooters_EmailSchemaId",
                table: "Footers",
                newName: "IX_Footers_EmailSchemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipientsList",
                table: "RecipientsList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logos",
                table: "Logos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Footers",
                table: "Footers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_EmailSchemas_EmailSchemaId",
                table: "Footers",
                column: "EmailSchemaId",
                principalTable: "EmailSchemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Logos_LogoId",
                table: "Footers",
                column: "LogoId",
                principalTable: "Logos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_RecipientsList_RecipientListId",
                table: "Recipients",
                column: "RecipientListId",
                principalTable: "RecipientsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipientsList_ServicesPermisions_ServiceId",
                table: "RecipientsList",
                column: "ServiceId",
                principalTable: "ServicesPermisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
