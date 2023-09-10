using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;


/// <summary>
/// 对公名称信息    a22
/// </summary>
public interface ICcicPhoneAppService :
    IReadOnlyAppService< 
                CcicPhoneDto, 
        CcicPhoneKey, 
        CcicPhoneGetListInput
      >
{

}