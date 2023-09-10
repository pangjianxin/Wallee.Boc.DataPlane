using System;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;


/// <summary>
/// 对公重要标志信息-组织    a35
/// </summary>
public interface ICcicSignOrgAppService :
    IReadOnlyAppService< 
                CcicSignOrgDto, 
        CcicSignOrgKey, 
        CcicSignOrgGetListInput
        >
{

}