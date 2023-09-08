using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCcicAddresses",
                table: "AppCcicAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "ADDR_TP",
                table: "AppCcicAddresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCcicAddresses",
                table: "AppCcicAddresses",
                columns: new[] { "CUSNO", "ADDR_TP", "ADDR_SN", "LGPER_CODE" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCcicAddresses",
                table: "AppCcicAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "ADDR_TP",
                table: "AppCcicAddresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCcicAddresses",
                table: "AppCcicAddresses",
                columns: new[] { "CUSNO", "LGPER_CODE" });
        }
    }
}
