using Microsoft.EntityFrameworkCore.Migrations;

namespace parakeet.Data.Migrations
{
    public partial class updatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                schema: "Identity",
                table: "orderItemHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeName",
                schema: "Identity",
                table: "orderItemHistories");
        }
    }
}
