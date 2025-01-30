using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessX_Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeCompositeKeyOnContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Contacts_ContactId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "ContactFirstName",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactLastName",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                columns: new[] { "Id", "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId_ContactFirstName_ContactLastName",
                table: "Customers",
                columns: new[] { "ContactId", "ContactFirstName", "ContactLastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Contacts_ContactId_ContactFirstName_ContactLastNa~",
                table: "Customers",
                columns: new[] { "ContactId", "ContactFirstName", "ContactLastName" },
                principalTable: "Contacts",
                principalColumns: new[] { "Id", "FirstName", "LastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Contacts_ContactId_ContactFirstName_ContactLastNa~",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactId_ContactFirstName_ContactLastName",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactLastName",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Contacts_ContactId",
                table: "Customers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
