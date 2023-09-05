using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddCcicAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCcicAddresses",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    ADDRTP = table.Column<string>(name: "ADDR_TP", type: "nvarchar(max)", nullable: false),
                    ADDRSN = table.Column<int>(name: "ADDR_SN", type: "int", nullable: false),
                    ADDRLANG = table.Column<string>(name: "ADDR_LANG", type: "nvarchar(max)", nullable: false),
                    CNRG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRVCMNCP = table.Column<string>(name: "PRVC_MNCP", type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNTY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDR1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSALC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RTNPTFLAG = table.Column<string>(name: "RTNPT_FLAG", type: "nvarchar(max)", nullable: false),
                    PSNAME = table.Column<string>(name: "PS_NAME", type: "nvarchar(max)", nullable: false),
                    CTYLNGCODE = table.Column<string>(name: "CTY_LNG_CODE", type: "nvarchar(max)", nullable: false),
                    CTYRGONRSKGRDCODE = table.Column<string>(name: "CTY_RGON_RSK_GRD_CODE", type: "nvarchar(max)", nullable: false),
                    RLTVUNNPYURBNCODE = table.Column<string>(name: "RLTV_UNNPY_URBN_CODE", type: "nvarchar(max)", nullable: false),
                    BKCDURBNCODE = table.Column<string>(name: "BKCD_URBN_CODE", type: "nvarchar(max)", nullable: false),
                    RELTPCODE = table.Column<string>(name: "REL_TP_CODE", type: "nvarchar(max)", nullable: false),
                    RELSTRTDT = table.Column<DateTime>(name: "REL_STRT_DT", type: "datetime2", nullable: false),
                    RELENDDT = table.Column<DateTime>(name: "REL_END_DT", type: "datetime2", nullable: false),
                    RELSTRTTIME = table.Column<DateTime>(name: "REL_STRT_TIME", type: "datetime2", nullable: false),
                    RELENDTIME = table.Column<DateTime>(name: "REL_END_TIME", type: "datetime2", nullable: false),
                    RELDES = table.Column<string>(name: "REL_DES", type: "nvarchar(max)", nullable: false),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: false),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: false),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: false),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: false),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: false),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: false),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: false),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: false),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: false),
                    RCRDVRSNSN = table.Column<long>(name: "RCRD_VRSN_SN", type: "bigint", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicAddresses", x => new { x.CUSNO, x.LGPERCODE });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCcicAddresses");
        }
    }
}
