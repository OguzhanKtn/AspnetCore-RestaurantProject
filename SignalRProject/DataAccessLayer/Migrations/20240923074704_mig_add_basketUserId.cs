using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_basketUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserID",
                table: "Baskets",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_AspNetUsers_UserID",
                table: "Baskets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_AspNetUsers_UserID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Baskets");
        }
    }
}
