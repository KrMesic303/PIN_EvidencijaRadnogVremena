using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencijaRadnogVremena.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToVisitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "Visits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "Visits");
        }
    }
}
