using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExportExcelToSQL.Migrations
{
    /// <inheritdoc />
    public partial class editTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Airports",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Airports");

            migrationBuilder.EnsureSchema(
                name: "Cargo");

            migrationBuilder.RenameTable(
                name: "Airports",
                newName: "Airport",
                newSchema: "Cargo");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                schema: "Cargo",
                table: "Airport",
                newName: "ZoneCodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airport",
                schema: "Cargo",
                table: "Airport",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Airport",
                schema: "Cargo",
                table: "Airport");

            migrationBuilder.RenameTable(
                name: "Airport",
                schema: "Cargo",
                newName: "Airports");

            migrationBuilder.RenameColumn(
                name: "ZoneCodeId",
                table: "Airports",
                newName: "ZoneId");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airports",
                table: "Airports",
                column: "Id");
        }
    }
}
