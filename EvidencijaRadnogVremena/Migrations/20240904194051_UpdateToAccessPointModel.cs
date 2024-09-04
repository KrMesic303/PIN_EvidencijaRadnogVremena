using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencijaRadnogVremena.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToAccessPointModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AccessPoints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AccessPoints");
        }
    }
}
