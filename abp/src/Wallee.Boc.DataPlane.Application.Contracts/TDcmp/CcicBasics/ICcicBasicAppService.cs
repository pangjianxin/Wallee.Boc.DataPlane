using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;


/// <summary>
/// 对公客户基础信息
/// </summary>
public interface ICcicBasicAppService : IReadOnlyAppService<CcicBasicDto, CcicBasicKey, CcicBasicGetListInput>
{

}