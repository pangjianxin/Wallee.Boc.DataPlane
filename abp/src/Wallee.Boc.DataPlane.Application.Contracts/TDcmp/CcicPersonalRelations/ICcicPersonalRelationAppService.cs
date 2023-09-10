using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;


/// <summary>
/// 对公人员关系    a24
/// </summary>
public interface ICcicPersonalRelationAppService :
    IReadOnlyAppService< 
                CcicPersonalRelationDto, 
        CcicPersonalRelationKey, 
        CcicPersonalRelationGetListInput
        >
{

}