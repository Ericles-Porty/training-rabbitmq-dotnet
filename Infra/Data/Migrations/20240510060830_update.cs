using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesTB_ProductsTB_ProductId",
                table: "PurchasesTB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasesTB",
                table: "PurchasesTB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsTB",
                table: "ProductsTB");

            migrationBuilder.RenameTable(
                name: "PurchasesTB",
                newName: "Purchases");

            migrationBuilder.RenameTable(
                name: "ProductsTB",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasesTB_ProductId",
                table: "Purchases",
                newName: "IX_Purchases_ProductId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "PurchasesTB");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductsTB");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_ProductId",
                table: "PurchasesTB",
                newName: "IX_PurchasesTB_ProductId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "ProductsTB",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasesTB",
                table: "PurchasesTB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsTB",
                table: "ProductsTB",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesTB_ProductsTB_ProductId",
                table: "PurchasesTB",
                column: "ProductId",
                principalTable: "ProductsTB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
