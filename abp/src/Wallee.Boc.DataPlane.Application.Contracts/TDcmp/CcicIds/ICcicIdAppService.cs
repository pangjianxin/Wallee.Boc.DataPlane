using System;
using Wallee.Boc.DataPlane.TDcmp.CcicIds.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;


/// <summary>
/// 对公证件信息    a20
/// </summary>
public interface ICcicIdAppService :
    IReadOnlyAppService< 
                CcicIdDto, 
        CcicIdKey, 
        CcicIdGetListInput
     >
{

}