using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class CreateOrderHistoryitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHistories_ClothingTypes_ClothingTypeId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_orderHistories_Designs_DesignId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.DropIndex(
                name: "IX_orderHistories_ClothingTypeId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.DropIndex(
                name: "IX_orderHistories_DesignId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.DropColumn(
                name: "ClothingTypeId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.DropColumn(
                name: "DesignId",
                schema: "Identity",
                table: "orderHistories");

            migrationBuilder.CreateTable(
                name: "Sizes",
                schema: "Identity",
                columns: table => new
                {
                    SizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "orderItemHistories",
                schema: "Identity",
                columns: table => new
                {
                    OrderItemHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHistoryId = table.Column<int>(nullable: false),
                    DesignId = table.Column<int>(nullable: false),
                    ClothingTypeId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItemHistories", x => x.OrderItemHistoryId);
                    table.ForeignKey(
                        name: "FK_orderItemHistories_ClothingTypes_ClothingTypeId",
                        column: x => x.ClothingTypeId,
                        principalSchema: "Identity",
                        principalTable: "ClothingTypes",
                        principalColumn: "ClothingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItemHistories_Designs_DesignId",
                        column: x => x.DesignId,
                        principalSchema: "Identity",
                        principalTable: "Designs",
                        principalColumn: "DesignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItemHistories_orderHistories_OrderHistoryId",
                        column: x => x.OrderHistoryId,
                        principalSchema: "Identity",
                        principalTable: "orderHistories",
                        principalColumn: "OrderHistoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItemHistories_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "Identity",
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Sizes",
                columns: new[] { "SizeId", "SizeName" },
                values: new object[,]
                {
                    { 1, "XS" },
                    { 2, "S" },
                    { 3, "M" },
                    { 4, "L" },
                    { 5, "XL" },
                    { 6, "XXL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItemHistories_ClothingTypeId",
                schema: "Identity",
                table: "orderItemHistories",
                column: "ClothingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemHistories_DesignId",
                schema: "Identity",
                table: "orderItemHistories",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemHistories_OrderHistoryId",
                schema: "Identity",
                table: "orderItemHistories",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemHistories_SizeId",
                schema: "Identity",
                table: "orderItemHistories",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItemHistories",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Sizes",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "ClothingTypeId",
                schema: "Identity",
                table: "orderHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesignId",
                schema: "Identity",
                table: "orderHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderHistories_ClothingTypeId",
                schema: "Identity",
                table: "orderHistories",
                column: "ClothingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_orderHistories_DesignId",
                schema: "Identity",
                table: "orderHistories",
                column: "DesignId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHistories_ClothingTypes_ClothingTypeId",
                schema: "Identity",
                table: "orderHistories",
                column: "ClothingTypeId",
                principalSchema: "Identity",
                principalTable: "ClothingTypes",
                principalColumn: "ClothingTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderHistories_Designs_DesignId",
                schema: "Identity",
                table: "orderHistories",
                column: "DesignId",
                principalSchema: "Identity",
                principalTable: "Designs",
                principalColumn: "DesignId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
