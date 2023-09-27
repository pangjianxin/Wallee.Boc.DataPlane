using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddConvertedCus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConvertedCus",
                columns: table => new
                {
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cusidt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepYavBal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepCurBal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Orgidt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConvertedCus", x => new { x.DataDate, x.Cusidt });
                },
                comment: "折效客户明细");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConvertedCus");
        }
    }
}
