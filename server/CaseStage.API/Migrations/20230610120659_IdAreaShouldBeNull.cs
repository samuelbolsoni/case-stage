using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStage.API.Migrations
{
    /// <inheritdoc />
    public partial class IdAreaShouldBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proccess_Areas_AreaId",
                table: "Proccess");

            migrationBuilder.DropForeignKey(
                name: "FK_ProccessPerson_Persons_PersonId",
                table: "ProccessPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ProccessSystems_SystemApps_SystemId",
                table: "ProccessSystems");

            migrationBuilder.DropIndex(
                name: "IX_ProccessSystems_SystemId",
                table: "ProccessSystems");

            migrationBuilder.DropIndex(
                name: "IX_ProccessPerson_PersonId",
                table: "ProccessPerson");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Proccess",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Proccess_Areas_AreaId",
                table: "Proccess",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proccess_Areas_AreaId",
                table: "Proccess");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Proccess",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProccessSystems_SystemId",
                table: "ProccessSystems",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProccessPerson_PersonId",
                table: "ProccessPerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proccess_Areas_AreaId",
                table: "Proccess",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProccessPerson_Persons_PersonId",
                table: "ProccessPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProccessSystems_SystemApps_SystemId",
                table: "ProccessSystems",
                column: "SystemId",
                principalTable: "SystemApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
