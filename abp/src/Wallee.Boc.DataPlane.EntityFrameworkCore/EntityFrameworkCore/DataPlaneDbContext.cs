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
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;
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
    public DbSet<CcicCusInfoWorkFlow> CcicCusInfoWorkFlows { get; set; }
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
    /// <summary>
    /// 字典-机构坐标
    /// </summary>
    public DbSet<OrganizationUnitCoordinate> OrganizationUnitCoordinates { get; set; }
    /// <summary>
    /// 折效客户机构分布情况
    /// </summary>
    public DbSet<ConvertedCusOrgUnit> ConvertedCusOrgUnits { get; set; }
    /// <summary>
    /// 折效客户明细
    /// </summary>
    public DbSet<ConvertedCus> ConvertedCus { get; set; }

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
        builder.ConfigureTDcmp();
        builder.ConfigureDataPlane();
    }
}
