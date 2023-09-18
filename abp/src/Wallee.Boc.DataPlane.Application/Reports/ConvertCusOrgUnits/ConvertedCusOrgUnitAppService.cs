using AutoFilterer.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public class ConvertedCusOrgUnitAppService : AbstractKeyReadOnlyAppService<ConvertedCusOrgUnit, ConvertedCusOrgUnitDto, ConvertedCusOrgUnitKey, ConvertedCusOrgUnitGetListInput>,
    IConvertedCusOrgUnitAppService
{
    private readonly IConvertedCusOrgUnitRepository _repository;

    public ConvertedCusOrgUnitAppService(IConvertedCusOrgUnitRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<ConvertedCusOrgUnit>> CreateFilteredQueryAsync(ConvertedCusOrgUnitGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }


    protected override IQueryable<ConvertedCusOrgUnit> ApplyDefaultSorting(IQueryable<ConvertedCusOrgUnit> query)
    {
        return query.OrderByDescending(it => it.DataDate);
    }

    public async Task CreateByFileAsync(CreateUpdateConvertedCusOrgUnitByFileDto input)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using var streamReader = new StreamReader(input.File.GetStream(), encoding: Encoding.GetEncoding("GB2312"));
        using var csv = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes,
            ShouldSkipRecord = args =>
            {
                if (args.Row.GetField<string>(0).IsNullOrEmpty())
                {
                    return true;
                }
                return false;
            },
        });

        csv.Context.RegisterClassMap(typeof(ConvertedCusOrgUnitMap));

        var records = csv.GetRecords<ConvertedCusOrgUnit>();

        await _repository.UpsertAsync(records);
    }

    protected override async Task<ConvertedCusOrgUnit> GetEntityByIdAsync(ConvertedCusOrgUnitKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.DataDate == id.DataDate &&
                e.Orgidt == id.Orgidt
            ));
    }
}
internal class ConvertedCusOrgUnitMap : ClassMapBase<ConvertedCusOrgUnit>
{
    public ConvertedCusOrgUnitMap()
    {
        Map(it => it.Label).Index(1);
        Map(it => it.UpOrgidt).Index(2);
        Map(it => it.Orgidt).Index(3);
        Map(it => it.DataDate).Index(4).Convert(it => DateTimeConverter(it.Row, 4, "yyyyMMdd")!.Value);
        Map(it => it.FirstLevel).Index(5);
        Map(it => it.SecondLevel).Index(6);
        Map(it => it.ThirdLevel).Index(7);
        Map(it => it.FourthLevel).Index(8);
        Map(it => it.FifthLevel).Index(9);
        Map(it => it.SixthLevel).Index(10);
    }
}