using System;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;


/// <summary>
/// 对公客户类别信息-组织    a09
/// </summary>
public interface ICcicCustomerTypeOrgAppService :
    IReadOnlyAppService<
                CcicCustomerTypeOrgDto,
        CcicCustomerTypeOrgKey,
        CcicCustomerTypeOrgGetListInput>
{

}