using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class MoveWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTDcmpWorkFlows");

            migrationBuilder.AlterTable(
                name: "AppCcicSignOrgs",
                comment: "对公重要标志信息-组织-a35",
                oldComment: "对公重要标志信息-组织    a35");

            migrationBuilder.AlterTable(
                name: "AppCcicRegisters",
                comment: "对公注册信息-a28",
                oldComment: "对公注册信息    a28");

            migrationBuilder.AlterTable(
                name: "AppCcicPractices",
                comment: "对公运营信息-a26",
                oldComment: "对公运营信息    a26");

            migrationBuilder.AlterTable(
                name: "AppCcicPhones",
                comment: "对公名称信息-a22",
                oldComment: "对公名称信息    a22");

            migrationBuilder.AlterTable(
                name: "AppCcicPersonalRelations",
                comment: "对公人员关系-a24",
                oldComment: "对公人员关系    a24");

            migrationBuilder.AlterTable(
                name: "AppCcicNames",
                comment: "对公名称信息-a22",
                oldComment: "对公名称信息    a22");

            migrationBuilder.AlterTable(
                name: "AppCcicIds",
                comment: "对公证件信息-a20",
                oldComment: "对公证件信息    a20");

            migrationBuilder.AlterTable(
                name: "AppCcicGeneralOrgs",
                comment: "对公概况-组织-a18",
                oldComment: "对公概况-组织    a18");

            migrationBuilder.AlterTable(
                name: "AppCcicCustomerTypes",
                comment: "对公客户类别信息-a08",
                oldComment: "对公客户类别信息    a08");

            migrationBuilder.AlterTable(
                name: "AppCcicCustomerTypeOrgs",
                comment: "对公客户类别信息-组织-a09",
                oldComment: "对公客户类别信息-组织    a09");

            migrationBuilder.AlterTable(
                name: "AppCcicAntiMoneyLaunderings",
                comment: "对公反洗钱信息-a02",
                oldComment: "对公反洗钱信息    a02");

            migrationBuilder.CreateTable(
                name: "AppCcicCusInfoWorkFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CompletedCount = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicCusInfoWorkFlows", x => x.Id);
                },
                comment: "信息管理平台工作流");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCcicCusInfoWorkFlows");

            migrationBuilder.AlterTable(
                name: "AppCcicSignOrgs",
                comment: "对公重要标志信息-组织    a35",
                oldComment: "对公重要标志信息-组织-a35");

            migrationBuilder.AlterTable(
                name: "AppCcicRegisters",
                comment: "对公注册信息    a28",
                oldComment: "对公注册信息-a28");

            migrationBuilder.AlterTable(
                name: "AppCcicPractices",
                comment: "对公运营信息    a26",
                oldComment: "对公运营信息-a26");

            migrationBuilder.AlterTable(
                name: "AppCcicPhones",
                comment: "对公名称信息    a22",
                oldComment: "对公名称信息-a22");

            migrationBuilder.AlterTable(
                name: "AppCcicPersonalRelations",
                comment: "对公人员关系    a24",
                oldComment: "对公人员关系-a24");

            migrationBuilder.AlterTable(
                name: "AppCcicNames",
                comment: "对公名称信息    a22",
                oldComment: "对公名称信息-a22");

            migrationBuilder.AlterTable(
                name: "AppCcicIds",
                comment: "对公证件信息    a20",
                oldComment: "对公证件信息-a20");

            migrationBuilder.AlterTable(
                name: "AppCcicGeneralOrgs",
                comment: "对公概况-组织    a18",
                oldComment: "对公概况-组织-a18");

            migrationBuilder.AlterTable(
                name: "AppCcicCustomerTypes",
                comment: "对公客户类别信息    a08",
                oldComment: "对公客户类别信息-a08");

            migrationBuilder.AlterTable(
                name: "AppCcicCustomerTypeOrgs",
                comment: "对公客户类别信息-组织    a09",
                oldComment: "对公客户类别信息-组织-a09");

            migrationBuilder.AlterTable(
                name: "AppCcicAntiMoneyLaunderings",
                comment: "对公反洗钱信息    a02",
                oldComment: "对公反洗钱信息-a02");

            migrationBuilder.CreateTable(
                name: "AppTDcmpWorkFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CompletedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTDcmpWorkFlows", x => x.Id);
                },
                comment: "信息管理平台工作流");
        }
    }
}
