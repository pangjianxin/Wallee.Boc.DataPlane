using AutoFilterer.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.Identity;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public class ConvertedCusOrgUnitAppService : AbstractKeyReadOnlyAppService<ConvertedCusOrgUnit, ConvertedCusOrgUnitDto, ConvertedCusOrgUnitKey, ConvertedCusOrgUnitGetListInput>,
    IConvertedCusOrgUnitAppService
{
    private readonly IConvertedCusOrgUnitRepository _repository;
    private readonly IOrganizationUnitRepository _organizationUnitRepository;

    public ConvertedCusOrgUnitAppService(
        IConvertedCusOrgUnitRepository repository,
        IOrganizationUnitRepository organizationUnitRepository) : base(repository)
    {
        _repository = repository;
        _organizationUnitRepository = organizationUnitRepository;
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
        using var streamReader = new StreamReader(input.File.GetStream(), encoding: Encoding.UTF8);
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

        csv.Context.RegisterClassMap(typeof(ConvertedCusOrgUnitReadingMap));

        var records = csv.GetRecords<ConvertedCusOrgUnit>();

        var checkedList = await CheckAndSetParentInfo(records);

        await _repository.UpsertAsync(checkedList);
    }

    private async Task<List<ConvertedCusOrgUnit>> CheckAndSetParentInfo(IEnumerable<ConvertedCusOrgUnit> records)
    {
        var orgUnits = await _organizationUnitRepository.GetListAsync();

        var recordList = records.ToList();

        foreach (var record in recordList)
        {
            var orgInfo = orgUnits.FirstOrDefault(it => it.GetOrgNo() == record.OrgIdentity);

            if (orgInfo != default)
            {
                if (orgInfo.ParentId.HasValue)
                {
                    var parent = orgUnits.First(it => it.Id == orgInfo.ParentId);

                    record.SetParentInfo(parent.DisplayName, parent.GetOrgNo());
                }
            }
        }

        return recordList.Where(it => !it.ParentIdentity.IsNullOrEmpty()).ToList();
    }

    public async Task<IRemoteStreamContent> DownloadFileAsync(DateTime dataDate)
    {
        var memory = new MemoryStream();
        var writer = new StreamWriter(memory);
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap(typeof(ConvertedCusOrgUnitWritingMap));
        var records = await _repository.GetListAsync(it => it.DataDate == dataDate);
        await csv.WriteRecordsAsync(records);
        await csv.FlushAsync();
        memory.Seek(0, SeekOrigin.Begin);
        return new RemoteStreamContent(memory, $"{dataDate:yyyyMMdd}-折效客户.csv", "text/csv");
    }

    protected override async Task<ConvertedCusOrgUnit> GetEntityByIdAsync(ConvertedCusOrgUnitKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.DataDate == id.DataDate &&
                e.OrgIdentity == id.OrgIdentity
            )))!;
    }

    public async Task<bool> DataExistedAsync(DateTime dataDate)
    {
        return await _repository.AnyAsync(it => it.DataDate == dataDate);
    }
}
internal class ConvertedCusOrgUnitReadingMap : ClassMap<ConvertedCusOrgUnit>
{
    public ConvertedCusOrgUnitReadingMap()
    {
        Map(it => it.OrgIdentity).Index(0);
        Map(it => it.DataDate).Index(1).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
        Map(it => it.FirstLevel).Index(2);
        Map(it => it.SecondLevel).Index(3);
        Map(it => it.ThirdLevel).Index(4);
        Map(it => it.FourthLevel).Index(5);
        Map(it => it.FifthLevel).Index(6);
        Map(it => it.SixthLevel).Index(7);
    }
}


internal class ConvertedCusOrgUnitWritingMap : ClassMap<ConvertedCusOrgUnit>
{
    public ConvertedCusOrgUnitWritingMap()
    {
        Map(it => it.DataDate).Index(0).Name("数据日期").TypeConverter<WritingDateTimeConverter>();
        Map(it => it.ParentName).Index(1).Name("标签");
        Map(it => it.ParentIdentity).Index(2).Name("上级机构号").TypeConverter<WritingOrganizationUnitStringConverter>();
        Map(it => it.OrgIdentity).Index(3).Name("机构号").TypeConverter<WritingOrganizationUnitStringConverter>();
        Map(it => it.FirstLevel).Index(4).Name("2000-20万日均客户数");
        Map(it => it.SecondLevel).Index(5).Name("20万-50万日均客户数");
        Map(it => it.ThirdLevel).Index(6).Name("50万-500万日均客户数");
        Map(it => it.FourthLevel).Index(7).Name("500万-2000万日均客户数");
        Map(it => it.FifthLevel).Index(8).Name("2000万-1亿元日均客户数");
        Map(it => it.SixthLevel).Index(9).Name("1亿元以上日均客户数");
    }
}