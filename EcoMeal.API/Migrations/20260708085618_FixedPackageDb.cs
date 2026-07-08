using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMeal.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedPackageDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No_Package",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Start_Pickup",
                table: "Package",
                newName: "StartPickup");

            migrationBuilder.RenameColumn(
                name: "End_Pickup",
                table: "Package",
                newName: "EndPickup");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Package",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "StartPickup",
                table: "Package",
                newName: "Start_Pickup");

            migrationBuilder.RenameColumn(
                name: "EndPickup",
                table: "Package",
                newName: "End_Pickup");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Package",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "No_Package",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
