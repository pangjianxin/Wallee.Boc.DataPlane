using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddCcicBasic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCcicBasics",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    ALCODE = table.Column<string>(name: "AL_CODE", type: "nvarchar(max)", nullable: true),
                    COMMLNG = table.Column<string>(name: "COMM_LNG", type: "nvarchar(max)", nullable: true),
                    CUSRLTECHNL = table.Column<string>(name: "CUSRL_TE_CHNL", type: "nvarchar(max)", nullable: true),
                    CSMGRTLRREFNO = table.Column<string>(name: "CSMGR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    OPNACORGREFNO = table.Column<string>(name: "OPNAC_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    BLGORGREFNO = table.Column<string>(name: "BLG_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    OPNACDT = table.Column<DateTime>(name: "OPNAC_DT", type: "datetime2", nullable: true),
                    CLSDT = table.Column<DateTime>(name: "CLS_DT", type: "datetime2", nullable: true),
                    LASTCNMDTPERI = table.Column<DateTime>(name: "LAST_CNMDT_PERI", type: "datetime2", nullable: false),
                    CSTST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSABLREASN = table.Column<string>(name: "DSABL_REASN", type: "nvarchar(max)", nullable: true),
                    DSABLREASNNOTE = table.Column<string>(name: "DSABL_REASN_NOTE", type: "nvarchar(max)", nullable: true),
                    PARTRLTPCODE = table.Column<string>(name: "PART_RL_TP_CODE", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: false),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: false),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: false),
                    RCRDVRSNSN = table.Column<decimal>(name: "RCRD_VRSN_SN", type: "decimal(18,2)", nullable: false),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicBasics", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公客户基础信息");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCcicBasics");
        }
    }
}
