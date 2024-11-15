using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockOfMachineParts.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Machine_MachineId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Parts_MachineId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Parts");

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "Parts",
                type: "TEXT",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "Parts");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Parts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineModel = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MachineId",
                table: "Parts",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Machine_MachineId",
                table: "Parts",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
