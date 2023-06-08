using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One.HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedAdressEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdressID",
                table: "Employees",
                column: "AdressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Adresses_AdressID",
                table: "Employees",
                column: "AdressID",
                principalTable: "Adresses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Adresses_AdressID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdressID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdressID",
                table: "Employees");
        }
    }
}
