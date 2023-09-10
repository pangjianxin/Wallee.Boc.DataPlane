using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class DataPlaneDbContext :
    AbpDbContext<DataPlaneDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    /// <summary>
    /// 对公客户基础信息
    /// </summary>
    public DbSet<CcicBasic> CcicBasics { get; set; }
    public DbSet<CcicAddress> CcicAddresses { get; set; }
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public DbSet<TDcmpWorkFlow> TDcmpWorkFlows { get; set; }
    /// <summary>
    /// 对公反洗钱信息    a02
    /// </summary>
    public DbSet<CcicAntiMoneyLaundering> CcicAntiMoneyLaunderings { get; set; }
    /// <summary>
    /// 对公客户类别信息-组织    a09
    /// </summary>
    public DbSet<CcicCustomerTypeOrg> CcicCustomerTypeOrgs { get; set; }
    /// <summary>
    /// 对公概况-组织    a18
    /// </summary>
    public DbSet<CcicGeneralOrg> CcicGeneralOrgs { get; set; }
    /// <summary>
    /// 对公证件信息    a20
    /// </summary>
    public DbSet<CcicId> CcicIds { get; set; }
    /// <summary>
    /// 对公隔离清单信息    a82
    /// </summary>
    public DbSet<CcicLsolationList> CcicLsolationLists { get; set; }
    /// <summary>
    /// 对公名称信息    a22
    /// </summary>
    public DbSet<CcicName> CcicNames { get; set; }
    /// <summary>
    /// 对公人员关系    a24
    /// </summary>
    public DbSet<CcicPersonalRelation> CcicPersonalRelations { get; set; }
    /// <summary>
    /// 对公名称信息    a22
    /// </summary>
    public DbSet<CcicPhone> CcicPhones { get; set; }
    /// <summary>
    /// 对公运营信息    a26
    /// </summary>
    public DbSet<CcicPractice> CcicPractices { get; set; }
    /// <summary>
    /// 对公注册信息    a28
    /// </summary>
    public DbSet<CcicRegister> CcicRegisters { get; set; }
    /// <summary>
    /// 对公重要标志信息-组织    a35
    /// </summary>
    public DbSet<CcicSignOrg> CcicSignOrgs { get; set; }
    /// <summary>
    /// 对公客户类别信息    a08
    /// </summary>
    public DbSet<CcicCustomerType> CcicCustomerTypes { get; set; }

    public DataPlaneDbContext(DbContextOptions<DataPlaneDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureTenantManagement();

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


        builder.Entity<TDcmpWorkFlow>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "TDcmpWorkFlows", DataPlaneConsts.DbSchema, table => table.HasComment("信息管理平台工作流"));
            b.ConfigureByConvention();
            b.HasKey(it => it.Id);
            b.Property(it => it.Comment).IsRequired(false).HasMaxLength(int.MaxValue);
            b.Property(it => it.CronExpression).IsRequired().HasMaxLength(100);
            b.Ignore(it => it.TotalTaskCount);
            /* Configure more properties here */
        });


        builder.Entity<CcicAntiMoneyLaundering>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicAntiMoneyLaunderings", DataPlaneConsts.DbSchema, table => table.HasComment("对公反洗钱信息    a02"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.AML_INF_SN,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });


        builder.Entity<CcicCustomerTypeOrg>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicCustomerTypeOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公客户类别信息-组织    a09"));
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
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicGeneralOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公概况-组织    a18"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });


        builder.Entity<CcicId>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicIds", DataPlaneConsts.DbSchema, table => table.HasComment("对公证件信息    a20"));
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


        builder.Entity<CcicLsolationList>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicLsolationLists", DataPlaneConsts.DbSchema, table => table.HasComment("对公隔离清单信息    a82"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });


        builder.Entity<CcicName>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicNames", DataPlaneConsts.DbSchema, table => table.HasComment("对公名称信息    a22"));
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
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPersonalRelations", DataPlaneConsts.DbSchema, table => table.HasComment("对公人员关系    a24"));
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
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPhones", DataPlaneConsts.DbSchema, table => table.HasComment("对公名称信息    a22"));
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
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicPractices", DataPlaneConsts.DbSchema, table => table.HasComment("对公运营信息    a26"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.OPRT_INF_SN,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });


        builder.Entity<CcicRegister>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicRegisters", DataPlaneConsts.DbSchema, table => table.HasComment("对公注册信息    a28"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });


        builder.Entity<CcicSignOrg>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicSignOrgs", DataPlaneConsts.DbSchema, table => table.HasComment("对公重要标志信息-组织    a35"));
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
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicCustomerTypes", DataPlaneConsts.DbSchema, table => table.HasComment("对公客户类别信息    a08"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.CUSNO,
                e.LGPER_CODE,
            });

            /* Configure more properties here */
        });
    }
}
