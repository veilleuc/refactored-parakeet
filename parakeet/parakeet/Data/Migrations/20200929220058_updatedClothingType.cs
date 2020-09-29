using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class updatedClothingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingTypes_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes");

            migrationBuilder.DropIndex(
                name: "IX_ClothingTypes_ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Identity",
                table: "ClothingTypes");

            migrationBuilder.AddColumn<float>(
                name: "price",
                schema: "Identity",
                table: "ClothingTypes",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                schema: "Identity",
                table: "ClothingTypes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "ClothingTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClothingTypes_ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingTypes_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
