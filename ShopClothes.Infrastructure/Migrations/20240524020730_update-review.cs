using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothes.Infrastructure.Migrations
{
    public partial class updatereview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReview_Bill_BillId",
                table: "ProductReview");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "ProductReview",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ProductReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReview_Bill_BillId",
                table: "ProductReview",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReview_Bill_BillId",
                table: "ProductReview");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ProductReview");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "ProductReview",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReview_Bill_BillId",
                table: "ProductReview",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
