using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One.HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class yangilik_qilma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_adressID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_adressID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "adressID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressID",
                table: "Employees",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressID",
                table: "Employees",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AddressID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "adressID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_adressID",
                table: "Employees",
                column: "adressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_adressID",
                table: "Employees",
                column: "adressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
