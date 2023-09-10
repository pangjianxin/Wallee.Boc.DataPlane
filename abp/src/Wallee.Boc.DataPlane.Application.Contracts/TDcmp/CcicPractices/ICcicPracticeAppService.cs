using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;


/// <summary>
/// 对公运营信息    a26
/// </summary>
public interface ICcicPracticeAppService :
    IReadOnlyAppService< 
                CcicPracticeDto, 
        CcicPracticeKey, 
        CcicPracticeGetListInput
        >
{

}