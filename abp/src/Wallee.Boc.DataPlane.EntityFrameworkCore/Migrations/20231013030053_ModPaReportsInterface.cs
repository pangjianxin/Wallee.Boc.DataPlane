using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class ModPaReportsInterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppCusOrgAdjusments");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppCusOrgAdjusments");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppConvertedCusOrgUnits");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppConvertedCus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppConvertedCus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppConvertedCus");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppConvertedCus");

            migrationBuilder.AlterColumn<string>(
                name: "Orgidt",
                table: "AppCusOrgAdjusments",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpOrgidt",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Orgidt",
                table: "AppCusOrgAdjusments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppCusOrgAdjusments",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppCusOrgAdjusments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpOrgidt",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppConvertedCusOrgUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppConvertedCusOrgUnits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppConvertedCusOrgUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppConvertedCus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppConvertedCus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppConvertedCus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppConvertedCus",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
