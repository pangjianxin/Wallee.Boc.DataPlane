using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;


/// <summary>
/// 对公人员关系    a24
/// </summary>
public class CcicPersonalRelationAppService : AbstractKeyReadOnlyAppService<CcicPersonalRelation, CcicPersonalRelationDto, CcicPersonalRelationKey, CcicPersonalRelationGetListInput>,
    ICcicPersonalRelationAppService
{
   

    private readonly ICcicPersonalRelationRepository _repository;

    public CcicPersonalRelationAppService(ICcicPersonalRelationRepository repository) : base(repository)
    {
        _repository = repository;
    }

 

    protected override async Task<CcicPersonalRelation> GetEntityByIdAsync(CcicPersonalRelationKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.REL_RL == id.REL_RL &&
                e.PRINT_CUSNO_YARD == id.PRINT_CUSNO_YARD &&
                e.LGPER_CODE == id.LGPER_CODE
            )))!;
    }

    protected override IQueryable<CcicPersonalRelation> ApplyDefaultSorting(IQueryable<CcicPersonalRelation> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicPersonalRelation>> CreateFilteredQueryAsync(CcicPersonalRelationGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
