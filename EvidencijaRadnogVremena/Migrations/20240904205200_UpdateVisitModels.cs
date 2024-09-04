using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencijaRadnogVremena.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AccessPoints_AccessPointId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Persons_PersonId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_AccessPointId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PersonId",
                table: "Visits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visits_AccessPointId",
                table: "Visits",
                column: "AccessPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PersonId",
                table: "Visits",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AccessPoints_AccessPointId",
                table: "Visits",
                column: "AccessPointId",
                principalTable: "AccessPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Persons_PersonId",
                table: "Visits",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
