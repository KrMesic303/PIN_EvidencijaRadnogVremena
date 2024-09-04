using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencijaRadnogVremena.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToCompanyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_CompanyId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Visits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CompanyId",
                table: "Visits",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
