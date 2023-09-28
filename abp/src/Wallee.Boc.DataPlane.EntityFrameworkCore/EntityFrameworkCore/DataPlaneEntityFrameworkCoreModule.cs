using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertCusOrgUnits;
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
using Wallee.Boc.DataPlane.WorkFlows;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore;

[DependsOn(
    typeof(DataPlaneDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule)
    )]
public class DataPlaneEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DataPlaneEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DataPlaneDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<CcicBasic, CcicBasicRepository>();
            options.AddRepository<CcicAddress, CcicAddressRepository>();
            options.AddRepository<CcicCusInfoWorkFlow, WorkFlows.CcicCusInfoWorkFlowRepository>();
            options.AddRepository<CcicAntiMoneyLaundering, CcicAntiMoneyLaunderingRepository>();
            options.AddRepository<CcicCustomerTypeOrg, CcicCustomerTypeOrgRepository>();
            options.AddRepository<CcicGeneralOrg, CcicGeneralOrgRepository>();
            options.AddRepository<CcicId, CcicIdRepository>();
            options.AddRepository<CcicName, CcicNameRepository>();
            options.AddRepository<CcicPersonalRelation, CcicPersonalRelationRepository>();
            options.AddRepository<CcicPhone, CcicPhoneRepository>();
            options.AddRepository<CcicPractice, CcicPracticeRepository>();
            options.AddRepository<CcicRegister, CcicRegisterRepository>();
            options.AddRepository<CcicSignOrg, CcicSignOrgRepository>();
            options.AddRepository<CcicCustomerType, CcicCustomerTypeRepository>();
            options.AddRepository<OrganizationUnitCoordinate, OrganizationUnitCoordinateRepository>();
            options.AddRepository<ConvertedCusOrgUnit, ConvertedCusOrgUnitRepository>();
            options.AddRepository<ConvertedCus, ConvertedCusRepository>();
            options.AddRepository<CusOrgAdjusment, CusOrgAdjusmentRepository>();
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also DataPlaneMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

    }
}
