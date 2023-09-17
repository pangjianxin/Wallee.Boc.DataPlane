using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Text;
using Wallee.Boc.DataPlane.TDcmp.Repositories;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public class ConvertedCusOrgUnitAppService : CrudAppService<ConvertedCusOrgUnit, ConvertedCusOrgUnitDto, Guid, ConvertedCusOrgUnitGetListInput, CreateUpdateConvertedCusOrgUnitDto, CreateUpdateConvertedCusOrgUnitDto>,
    IConvertedCusOrgUnitAppService
{
    protected override string GetPolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Default;
    protected override string GetListPolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Default;
    protected override string CreatePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Create;
    protected override string UpdatePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Update;
    protected override string DeletePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Delete;

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

    public Task CreateByFileAsync(CreateUpdateConvertedCusOrgUnitByFileDto input)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using var streamReader = new StreamReader(input.File.GetStream());
        using var csv = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes,
            Delimiter = "\u0001|\u0001",
            ShouldSkipRecord = args =>
            {
                if (args.Row.Parser.RawRecord.StartsWith("|||diip-control|||"))
                {
                    return true;
                }
                return false;
            },
        });

        csv.Context.RegisterClassMap(typeof(ConvertedCusOrgUnitMap));

        var records = csv.GetRecords<ConvertedCusOrgUnit>();

        foreach (var item in records)
        {
            Console.WriteLine(item.Orgidt);
        }
    }
}
internal class ConvertedCusOrgUnitMap : ClassMap<ConvertedCusOrgUnit>
{
    public ConvertedCusOrgUnitMap()
    {
        Map(it => it.UpOrgidt).Index(0);
        Map(it => it.Orgidt).Index(1);
        Map(it => it.FirstLevel).Index(2);
        Map(it => it.SecondLevel).Index(3);
        Map(it => it.ThirdLevel).Index(4);
        Map(it => it.FourthLevel).Index(5);
        Map(it => it.FifthLevel).Index(6);
        Map(it => it.SixthLevel).Index(7);
    }
}