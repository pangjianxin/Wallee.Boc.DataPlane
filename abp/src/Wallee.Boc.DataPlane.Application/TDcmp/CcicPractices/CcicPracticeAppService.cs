using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;


/// <summary>
/// 对公运营信息    a26
/// </summary>
public class CcicPracticeAppService : AbstractKeyReadOnlyAppService<CcicPractice, CcicPracticeDto, CcicPracticeKey, CcicPracticeGetListInput>,
    ICcicPracticeAppService
{
  

    private readonly ICcicPracticeRepository _repository;

    public CcicPracticeAppService(ICcicPracticeRepository repository) : base(repository)
    {
        _repository = repository;
    }

  

    protected override async Task<CcicPractice> GetEntityByIdAsync(CcicPracticeKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.OPRT_INF_SN == id.OPRT_INF_SN &&
                e.LGPER_CODE == id.LGPER_CODE
            )))!;
    }

    protected override IQueryable<CcicPractice> ApplyDefaultSorting(IQueryable<CcicPractice> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicPractice>> CreateFilteredQueryAsync(CcicPracticeGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(input);
    }
}
