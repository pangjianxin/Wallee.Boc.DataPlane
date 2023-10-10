using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class ModPaReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppConvertedCus");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppConvertedCus");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppCusOrgAdjusments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppCusOrgAdjusments",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppCusOrgAdjusments");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppCusOrgAdjusments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppConvertedCusOrgUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppConvertedCusOrgUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppConvertedCus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppConvertedCus",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
