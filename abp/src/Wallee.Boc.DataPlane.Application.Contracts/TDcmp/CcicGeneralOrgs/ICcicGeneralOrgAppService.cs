using System;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;


/// <summary>
/// 对公概况-组织    a18
/// </summary>
public interface ICcicGeneralOrgAppService :
    IReadOnlyAppService< 
                CcicGeneralOrgDto, 
        CcicGeneralOrgKey, 
        CcicGeneralOrgGetListInput
       >
{

}