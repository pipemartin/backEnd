using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class v106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cargoId",
                table: "Empleado",
                newName: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Cargo_CargoId",
                table: "Empleado",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Cargo_CargoId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "Empleado",
                newName: "cargoId");
        }
    }
}
