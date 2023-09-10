using System;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;


/// <summary>
/// 对公注册信息    a28
/// </summary>
public interface ICcicRegisterAppService :
    IReadOnlyAppService< 
                CcicRegisterDto, 
        CcicRegisterKey, 
        CcicRegisterGetListInput
        >
{

}