using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One.HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi_with_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "sample@mail.com",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "Addressline1", "Addressline2", "City", "Country", "PostalCode" },
                values: new object[] { 17, "Amir Temur , 1", "Amir temur , 2", "toshkent", "Uzbekiston", "141458" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "sample@mail.com");
        }
    }
}
