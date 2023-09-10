using System;
using Wallee.Boc.DataPlane.TDcmp.CcicNames.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;


/// <summary>
/// 对公名称信息    a22
/// </summary>
public interface ICcicNameAppService :
    IReadOnlyAppService< 
                CcicNameDto, 
        CcicNameKey, 
        CcicNameGetListInput
       >
{

}