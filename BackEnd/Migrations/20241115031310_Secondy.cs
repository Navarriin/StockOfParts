using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockOfMachineParts.Migrations
{
    /// <inheritdoc />
    public partial class Secondy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valueUnit",
                table: "Parts",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Parts",
                newName: "valueUnit");
        }
    }
}
