using System;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;


/// <summary>
/// 对公客户类别信息    a08
/// </summary>
public interface ICcicCustomerTypeAppService :
    IReadOnlyAppService< 
                CcicCustomerTypeDto, 
        CcicCustomerTypeKey, 
        CcicCustomerTypeGetListInput
       >
{

}