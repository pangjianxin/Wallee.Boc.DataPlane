using AutoFilterer.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;


public class CcicAddressAppService : AbstractKeyReadOnlyAppService<CcicAddress, CcicAddressDto, CcicAddressKey, CcicAddressGetListInput>,
    ICcicAddressAppService
{

    private readonly ICcicAddressRepository _repository;

    public CcicAddressAppService(ICcicAddressRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicAddress> GetEntityByIdAsync(CcicAddressKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicAddress> ApplyDefaultSorting(IQueryable<CcicAddress> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicAddress>> CreateFilteredQueryAsync(CcicAddressGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(input)
            ;
    }
}
