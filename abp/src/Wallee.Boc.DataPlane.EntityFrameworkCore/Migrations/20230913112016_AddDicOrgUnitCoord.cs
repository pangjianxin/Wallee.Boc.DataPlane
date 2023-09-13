using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddDicOrgUnitCoord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCcicLsolationLists");

            migrationBuilder.CreateTable(
                name: "AppOrganizationUnitCoordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    OrgNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrganizationUnitCoordinates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOrganizationUnitCoordinates");

            migrationBuilder.CreateTable(
                name: "AppCcicLsolationLists",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: false),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: false),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: false),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: false),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: false),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: false),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    QUARNREASN = table.Column<string>(name: "QUARN_REASN", type: "nvarchar(max)", nullable: true),
                    QUARNSTS = table.Column<string>(name: "QUARN_STS", type: "nvarchar(max)", nullable: true),
                    QUARNTP = table.Column<string>(name: "QUARN_TP", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicLsolationLists", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公隔离清单信息    a82");
        }
    }
}
