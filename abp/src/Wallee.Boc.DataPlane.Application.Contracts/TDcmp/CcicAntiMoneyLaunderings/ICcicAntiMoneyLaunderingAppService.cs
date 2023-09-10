using System;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;


/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
public interface ICcicAntiMoneyLaunderingAppService :
    IReadOnlyAppService<
                CcicAntiMoneyLaunderingDto,
        CcicAntiMoneyLaunderingKey,
        CcicAntiMoneyLaunderingGetListInput>
{

}