using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;


public interface ICcicAddressAppService :
    IReadOnlyAppService<
        CcicAddressDto,
        CcicAddressKey,
        CcicAddressGetListInput>
{

}