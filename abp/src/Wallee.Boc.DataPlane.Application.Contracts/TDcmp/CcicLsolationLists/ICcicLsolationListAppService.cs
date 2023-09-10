using System;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;


/// <summary>
/// 对公隔离清单信息    a82
/// </summary>
public interface ICcicLsolationListAppService :
    IReadOnlyAppService< 
                CcicLsolationListDto, 
        CcicLsolationListKey, 
        CcicLsolationListGetListInput
      >
{

}