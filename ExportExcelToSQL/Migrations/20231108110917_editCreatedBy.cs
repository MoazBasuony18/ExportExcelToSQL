using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExportExcelToSQL.Migrations
{
    /// <inheritdoc />
    public partial class editCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "Cargo",
                table: "Airport",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Cargo",
                table: "Airport");
        }
    }
}
