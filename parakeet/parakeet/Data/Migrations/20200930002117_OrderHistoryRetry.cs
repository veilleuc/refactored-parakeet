using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class OrderHistoryRetry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderHistories",
                schema: "Identity",
                columns: table => new
                {
                    OrderHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ClothingTypeId = table.Column<int>(nullable: false),
                    DesignId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderHistories", x => x.OrderHistoryId);
                    table.ForeignKey(
                        name: "FK_orderHistories_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderHistories_ClothingTypes_ClothingTypeId",
                        column: x => x.ClothingTypeId,
                        principalSchema: "Identity",
                        principalTable: "ClothingTypes",
                        principalColumn: "ClothingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderHistories_Designs_DesignId",
                        column: x => x.DesignId,
                        principalSchema: "Identity",
                        principalTable: "Designs",
                        principalColumn: "DesignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderHistories_ApplicationUserId",
                schema: "Identity",
                table: "orderHistories",
                column: "ApplicationUserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderHistories",
                schema: "Identity");
        }
    }
}
