using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class addClothingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingTypes",
                schema: "Identity",
                columns: table => new
                {
                    ClothingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingTypes", x => x.ClothingTypeId);
                    table.ForeignKey(
                        name: "FK_ClothingTypes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingTypes_ApplicationUserId",
                schema: "Identity",
                table: "ClothingTypes",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingTypes",
                schema: "Identity");
        }
    }
}
