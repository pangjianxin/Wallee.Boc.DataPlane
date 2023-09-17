using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddConvertedCusInfoOrgUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConvertedCusOrgUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpOrgidt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orgidt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConvertedCusOrgUnits", x => x.Id);
                },
                comment: "折效客户机构分布情况");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConvertedCusOrgUnits");
        }
    }
}
