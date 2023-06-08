using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStage.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateOtherTablesWithFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teste",
                table: "Areas");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Proccess",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Proccess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Documentation",
                table: "Proccess",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdParent",
                table: "Proccess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Proccess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProccessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileModel_Proccess_ProccessId",
                        column: x => x.ProccessId,
                        principalTable: "Proccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_ProccessId",
                table: "FileModel",
                column: "ProccessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModel");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Proccess");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Proccess");

            migrationBuilder.DropColumn(
                name: "Documentation",
                table: "Proccess");

            migrationBuilder.DropColumn(
                name: "IdParent",
                table: "Proccess");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Proccess");

            migrationBuilder.AddColumn<string>(
                name: "Teste",
                table: "Areas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
