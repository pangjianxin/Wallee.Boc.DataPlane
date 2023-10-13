using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPropNameInConvertedCusOrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpOrgidt",
                table: "AppConvertedCusOrgUnits",
                newName: "ParentIdentity");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "AppConvertedCusOrgUnits",
                newName: "ParentName");

            migrationBuilder.RenameColumn(
                name: "Orgidt",
                table: "AppConvertedCusOrgUnits",
                newName: "Identity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "AppConvertedCusOrgUnits",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "ParentIdentity",
                table: "AppConvertedCusOrgUnits",
                newName: "UpOrgidt");

            migrationBuilder.RenameColumn(
                name: "Identity",
                table: "AppConvertedCusOrgUnits",
                newName: "Orgidt");
        }
    }
}
