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
        });


        builder.Entity<CcicAddress>(b =>
        {
            b.ToTable(DataPlaneConsts.DbTablePrefix + "CcicAddresses", DataPlaneConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(e => new
            {
                e.CUSNO,
                e.LGPER_CODE,
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
            /* Configure more properties here */
        });
    }
}
