using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class AddDesignModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designs",
                schema: "Identity",
                columns: table => new
                {
                    DesignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignArray = table.Column<byte[]>(nullable: true),
                    DesignName = table.Column<string>(nullable: true),
                    Popularitycounter = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    AdminViewed = table.Column<bool>(nullable: false),
                    NatureTag = table.Column<bool>(nullable: false),
                    FunnyTag = table.Column<bool>(nullable: false),
                    AbstractTag = table.Column<bool>(nullable: false),
                    GameTag = table.Column<bool>(nullable: false),
                    MusicTag = table.Column<bool>(nullable: false),
                    MovieTag = table.Column<bool>(nullable: false),
                    CoolTag = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designs", x => x.DesignId);
                    table.ForeignKey(
                        name: "FK_Designs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designs_ApplicationUserId",
                schema: "Identity",
                table: "Designs",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designs",
                schema: "Identity");
        }
    }
}
