using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore
{
    public static class DataPlaneTDcmpDbContextModelCreatingExtensions
    {
        public static void ConfigureTDcmp(this ModelBuilder builder)
        {
            builder.Entity<CcicBasic>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicBasics", DataPlaneConsts.DbSchema, table => table.HasComment("对公客户基础信息"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });

                //b.Property(it => it.CUSNO).HasComment("客户号").IsRequired(true).HasMaxLength(10);
                //b.Property(it => it.LGPER_CODE).HasComment("法人编码").IsRequired(true).HasMaxLength(3);

                //b.Property(it => it.AL_CODE).HasComment("终身编码").IsRequired(true).HasMaxLength(17);

                //b.Property(it => it.COMM_LNG).HasComment("通讯语言").IsRequired(false).HasMaxLength(2);

                //b.Property(it => it.LGPER_CODE).HasComment("法人编码").IsRequired(true).HasMaxLength(3);

                //b.Property(it => it.LGPER_CODE).HasComment("法人编码").IsRequired(true).HasMaxLength(3);

            });


            builder.Entity<CcicAddress>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicAddresses", DataPlaneConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.ADDR_TP,
                    e.ADDR_SN,
                    e.LGPER_CODE
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicCusInfoWorkFlow>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicCusInfoWorkFlows", DataPlaneConsts.DbSchema, table => table.HasComment("信息管理平台工作流"));
                b.ConfigureByConvention();
                b.HasKey(it => it.Id);
                b.Property(it => it.Comment).IsRequired(false).HasMaxLength(int.MaxValue);
                b.Ignore(it => it.TotalTaskCount);
                /* Configure more properties here */
            });


            builder.Entity<CcicAntiMoneyLaundering>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicAntiMoneyLaunderings", DataPlaneConsts.DbSchema, table => table.HasComment("对公反洗钱信息-a02"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.AML_INF_SN,
                    e.LGPER_CODE,
                });

                b.Property(it => it.EXPC_MO_TXN_SZ_AMT).HasColumnType("decimal(18,3)");

                /* Configure more properties here */
            });


            builder.Entity<CcicCustomerTypeOrg>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicCustomerTypeOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公客户类别信息-组织-a09"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicGeneralOrg>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicGeneralOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公概况-组织-a18"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });
                b.Property(it => it.EXST_OURBK_EQU_PCT).HasColumnType("decimal(6,2)");
                /* Configure more properties here */
            });


            builder.Entity<CcicId>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicIds", DataPlaneConsts.DbSchema, table => table.HasComment("对公证件信息-a20"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.CRDT_TP,
                    e.CRDT_SN,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicName>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicNames", DataPlaneConsts.DbSchema, table => table.HasComment("对公名称信息-a22"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.CUS_NAME_LANG,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicPersonalRelation>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPersonalRelations", DataPlaneConsts.DbSchema, table => table.HasComment("对公人员关系-a24"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.REL_RL,
                    e.PRINT_CUSNO_YARD,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicPhone>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPhones", DataPlaneConsts.DbSchema, table => table.HasComment("对公名称信息-a22"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.UNIT_TEL_TP,
                    e.CNTEL_SN,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicPractice>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPractices", DataPlaneConsts.DbSchema, table => table.HasComment("对公运营信息-a26"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.OPRT_INF_SN,
                    e.LGPER_CODE,
                });
                b.Property(it => it.AST_TAMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.BRND_VAL).HasColumnType("decimal(18,3)");
                b.Property(it => it.CO_EMPE_AVGAG).HasColumnType("decimal(5,2)");
                b.Property(it => it.NTAST_AMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.SALES_AMT).HasColumnType("decimal(18,3)");

                /* Configure more properties here */
            });


            builder.Entity<CcicRegister>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicRegisters", DataPlaneConsts.DbSchema, table => table.HasComment("对公注册信息-a28"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });
                b.Property(it => it.ARCPT_AMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.ISSU_EQU_AMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.ORGN_FNDS_AMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.RC_AMT).HasColumnType("decimal(18,3)");
                b.Property(it => it.SHR_TOTAL).HasColumnType("decimal(24,6)");
                /* Configure more properties here */
            });


            builder.Entity<CcicSignOrg>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicSignOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公重要标志信息-组织-a35"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });

                /* Configure more properties here */
            });


            builder.Entity<CcicCustomerType>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicCustomerTypes", DataPlaneConsts.DbSchema, table => table.HasComment("对公客户类别信息-a08"));
                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.CUSNO,
                    e.LGPER_CODE,
                });

                b.Property(it => it.AVY_SCOR).HasColumnType("decimal(5,2)");
                b.Property(it => it.CUS_LYLT).HasColumnType("decimal(6,2)");
            });
        }

        public static void ConfigureDataPlane(this ModelBuilder builder)
        {
            builder.Entity<OrganizationUnitCoordinate>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "OrganizationUnitCoordinates", DataPlaneConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(it => it.OrgName).IsRequired().HasMaxLength(128);
                b.Property(it => it.OrgNo).IsRequired().HasMaxLength(32);
                /* Configure more properties here */
            });

            builder.Entity<ConvertedCusOrgUnit>(b =>
            {
                b.ToTable(DataPlaneConsts.DbTablePrefix + "ConvertedCusOrgUnits", DataPlaneConsts.DbSchema, table => table.HasComment("折效客户机构分布情况"));

                b.ConfigureByConvention();

                b.HasKey(it => new { it.DataDate, it.Orgidt });
                b.Property(it => it.DataDate).HasColumnOrder(0).IsRequired();
                b.Property(it => it.Orgidt).HasColumnOrder(1).HasMaxLength(8).IsRequired();
                b.Property(it => it.FirstLevel).HasColumnType("decimal(18,2)");
                b.Property(it => it.SecondLevel).HasColumnType("decimal(18,2)");
                b.Property(it => it.ThirdLevel).HasColumnType("decimal(18,2)");
                b.Property(it => it.FourthLevel).HasColumnType("decimal(18,2)");
                b.Property(it => it.FifthLevel).HasColumnType("decimal(18,2)");
                b.Property(it => it.SixthLevel).HasColumnType("decimal(18,2)");
                /* Configure more properties here */
            });
        }
    }
}
