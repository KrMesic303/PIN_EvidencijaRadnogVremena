﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencijaRadnogVremena.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OIB",
                table: "Persons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OIB",
                table: "Persons");
        }
    }
}
