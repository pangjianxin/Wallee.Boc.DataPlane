using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdjAndModOrgidt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCusOrgAdjusments");

            migrationBuilder.RenameColumn(
                name: "Orgidt",
                table: "AppConvertedCus",
                newName: "OrgIdentity");

            migrationBuilder.RenameColumn(
                name: "Cusidt",
                table: "AppConvertedCus",
                newName: "CusIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrgIdentity",
                table: "AppConvertedCus",
                newName: "Orgidt");

            migrationBuilder.RenameColumn(
                name: "CusIdentity",
                table: "AppConvertedCus",
                newName: "Cusidt");

            migrationBuilder.CreateTable(
                name: "AppCusOrgAdjusments",
                columns: table => new
                {
                    Cusidt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Orgidt = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCusOrgAdjusments", x => x.Cusidt);
                },
                comment: "客户机构调整");
        }
    }
}
