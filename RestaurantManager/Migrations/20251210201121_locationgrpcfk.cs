using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManager.Migrations
{
    /// <inheritdoc />
    public partial class locationgrpcfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Kitchen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kitchen_LocationID",
                table: "Kitchen",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchen_Location_LocationID",
                table: "Kitchen",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitchen_Location_LocationID",
                table: "Kitchen");

            migrationBuilder.DropIndex(
                name: "IX_Kitchen_LocationID",
                table: "Kitchen");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Kitchen");
        }
    }
}
