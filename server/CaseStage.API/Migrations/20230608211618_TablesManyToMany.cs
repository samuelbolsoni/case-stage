using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStage.API.Migrations
{
    /// <inheritdoc />
    public partial class TablesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonModelProccessModel",
                columns: table => new
                {
                    PersonsId = table.Column<int>(type: "int", nullable: false),
                    ProccessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModelProccessModel", x => new { x.PersonsId, x.ProccessId });
                    table.ForeignKey(
                        name: "FK_PersonModelProccessModel_Person_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonModelProccessModel_Proccess_ProccessId",
                        column: x => x.ProccessId,
                        principalTable: "Proccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProccessModelSystemModel",
                columns: table => new
                {
                    ProccessId = table.Column<int>(type: "int", nullable: false),
                    SystemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProccessModelSystemModel", x => new { x.ProccessId, x.SystemsId });
                    table.ForeignKey(
                        name: "FK_ProccessModelSystemModel_Proccess_ProccessId",
                        column: x => x.ProccessId,
                        principalTable: "Proccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProccessModelSystemModel_System_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "System",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProccessPerson",
                columns: table => new
                {
                    ProccessId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProccessPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProccessPerson_Proccess_ProccessId",
                        column: x => x.ProccessId,
                        principalTable: "Proccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProccessSystem",
                columns: table => new
                {
                    ProccessId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProccessSystem_System_SystemId",
                        column: x => x.SystemId,
                        principalTable: "System",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonModelProccessModel_ProccessId",
                table: "PersonModelProccessModel",
                column: "ProccessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProccessModelSystemModel_SystemsId",
                table: "ProccessModelSystemModel",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProccessPerson_PersonId",
                table: "ProccessPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProccessPerson_ProccessId",
                table: "ProccessPerson",
                column: "ProccessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProccessSystem_SystemId",
                table: "ProccessSystem",
                column: "SystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonModelProccessModel");

            migrationBuilder.DropTable(
                name: "ProccessModelSystemModel");

            migrationBuilder.DropTable(
                name: "ProccessPerson");

            migrationBuilder.DropTable(
                name: "ProccessSystem");
        }
    }
}
