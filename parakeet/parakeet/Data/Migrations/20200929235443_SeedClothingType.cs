using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class SeedClothingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "ClothingTypes",
                columns: new[] { "ClothingTypeId", "price", "type" },
                values: new object[,]
                {
                    { 1, 20f, "Short Sleeve Shirt" },
                    { 2, 35f, "Long Sleeve Shirt" },
                    { 3, 50f, "Jacket" },
                    { 4, 40f, "Hoodie" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "ClothingTypes",
                keyColumn: "ClothingTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "ClothingTypes",
                keyColumn: "ClothingTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "ClothingTypes",
                keyColumn: "ClothingTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "ClothingTypes",
                keyColumn: "ClothingTypeId",
                keyValue: 4);
        }
    }
}
