using AutoFilterer.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.Identity;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;


/// <summary>
/// 折效客户明细
/// </summary>
public class ConvertedCusAppService : AbstractKeyReadOnlyAppService<ConvertedCus, ConvertedCusDto, ConvertedCusKey, ConvertedCusGetListInput>,
    IConvertedCusAppService
{

    private readonly IConvertedCusRepository _repository;
    private readonly IOrganizationUnitCacheProvider _organizationUnitCacheProvider;

    public ConvertedCusAppService(
        IConvertedCusRepository repository, IOrganizationUnitCacheProvider organizationUnitCacheProvider) : base(repository)
    {
        _repository = repository;
        _organizationUnitCacheProvider = organizationUnitCacheProvider;
    }

    protected override async Task<ConvertedCus> GetEntityByIdAsync(ConvertedCusKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.DataDate == id.DataDate &&
                e.CusIdentity == id.CusIdentity
            )))!;
    }

    protected override IQueryable<ConvertedCus> ApplyDefaultSorting(IQueryable<ConvertedCus> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.DataDate);
    }

    public async Task CreateByFileAsync(CreateUpdateConvertedCusByFileDto input)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using var streamReader = new StreamReader(input.File.GetStream(), encoding: Encoding.GetEncoding("GB2312"));
        using var csv = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes,
            ShouldSkipRecord = args =>
            {
                if (
                args.Row.GetField<string>(1).IsNullOrEmpty()
                || args.Row.GetField<string>(2).IsNullOrEmpty()
                || args.Row.GetField<string>(3).IsNullOrEmpty()
                || args.Row.GetField<string>(4).IsNullOrEmpty()
                || args.Row.GetField<string>(5).IsNullOrEmpty())
                {
                    return true;
                }
                return false;
            },
        });

        csv.Context.RegisterClassMap(typeof(ConvertedCusReadingMap));

        var records = csv.GetRecords<ConvertedCus>();

        await _repository.UpsertAsync(records);
    }
    protected override async Task<IQueryable<ConvertedCus>> CreateFilteredQueryAsync(ConvertedCusGetListInput input)
    {
        var queryable = await base.CreateFilteredQueryAsync(input);

        var visibleOrgs = (await _organizationUnitCacheProvider.GetVisibleOrganizationUnitsAsync(CurrentUser.GetOrganizationUnitCode()))
            .Select(it => it.GetProperty<string>("OrgNo")).ToList();

        queryable = queryable.Where(it => visibleOrgs.Contains(it.OrgIdentity));

        queryable = queryable.WhereIf(input.OrgIdentity != default, it => it.OrgIdentity == input.OrgIdentity);

        return queryable.ApplyFilter(input);
    }
}

internal class ConvertedCusReadingMap : ClassMap<ConvertedCus>
{
    public ConvertedCusReadingMap()
    {
        Map(it => it.DataDate).Index(0).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
        Map(it => it.CusIdentity).Index(1);
        Map(it => it.CusName).Index(2);
        Map(it => it.DepYavBal).Index(3);
        Map(it => it.DepCurBal).Index(4);
        Map(it => it.OrgIdentity).Index(5);
        Map(it => it.OrgName).Index(6);
    }
}

