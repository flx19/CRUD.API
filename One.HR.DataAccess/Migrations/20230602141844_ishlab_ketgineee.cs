using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One.HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ishlab_ketgineee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AdressID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "AdressID",
                table: "Employees",
                newName: "adressID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_AdressID",
                table: "Employees",
                newName: "IX_Employees_adressID");

            migrationBuilder.AlterColumn<int>(
                name: "adressID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_adressID",
                table: "Employees",
                column: "adressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_adressID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "adressID",
                table: "Employees",
                newName: "AdressID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_adressID",
                table: "Employees",
                newName: "IX_Employees_AdressID");

            migrationBuilder.AlterColumn<int>(
                name: "AdressID",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AdressID",
                table: "Employees",
                column: "AdressID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }
    }
}
