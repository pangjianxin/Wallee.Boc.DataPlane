using AutoFilterer.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;


/// <summary>
/// 客户机构调整
/// </summary>
public class CusOrgAdjusmentAppService : AbstractKeyReadOnlyAppService<CusOrgAdjusment, CusOrgAdjusmentDto, CusOrgAdjusmentKey, CusOrgAdjusmentGetListInput>,
    ICusOrgAdjusmentAppService
{
    private readonly ICusOrgAdjusmentRepository _repository;

    public CusOrgAdjusmentAppService(ICusOrgAdjusmentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CusOrgAdjusment> GetEntityByIdAsync(CusOrgAdjusmentKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.Cusidt == id.Cusidt
            ));
    }

    protected override IQueryable<CusOrgAdjusment> ApplyDefaultSorting(IQueryable<CusOrgAdjusment> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.Cusidt);
    }

    public async Task CreateByFileAsync(CreateUpdateCusOrgAdjusmentByFileDto input)
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
                args.Row.GetField<string>(0).IsNullOrEmpty()
                || args.Row.GetField<string>(1).IsNullOrEmpty())
                {
                    return true;
                }
                return false;
            },
        });

        csv.Context.RegisterClassMap(typeof(CusOrgAdjusmentReadingMap));

        var records = csv.GetRecords<CusOrgAdjusment>();

        await _repository.UpsertAsync(records);
    }

    protected override async Task<IQueryable<CusOrgAdjusment>> CreateFilteredQueryAsync(CusOrgAdjusmentGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}

internal class CusOrgAdjusmentReadingMap : ClassMap<ConvertedCus>
{
    public CusOrgAdjusmentReadingMap()
    {
        Map(it => it.Cusidt).Index(0);
        Map(it => it.Orgidt).Index(1);
    }
}

