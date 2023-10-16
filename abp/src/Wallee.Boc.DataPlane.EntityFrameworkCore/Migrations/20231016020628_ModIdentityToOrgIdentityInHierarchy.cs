using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class ModIdentityToOrgIdentityInHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identity",
                table: "AppOrgUnitHierarchies",
                newName: "OrgIdentity");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrgUnitHierarchies_Identity",
                table: "AppOrgUnitHierarchies",
                newName: "IX_AppOrgUnitHierarchies_OrgIdentity");

            migrationBuilder.RenameColumn(
                name: "Identity",
                table: "AppConvertedCusOrgUnits",
                newName: "OrgIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrgIdentity",
                table: "AppOrgUnitHierarchies",
                newName: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrgUnitHierarchies_OrgIdentity",
                table: "AppOrgUnitHierarchies",
                newName: "IX_AppOrgUnitHierarchies_Identity");

            migrationBuilder.RenameColumn(
                name: "OrgIdentity",
                table: "AppConvertedCusOrgUnits",
                newName: "Identity");
        }
    }
}
