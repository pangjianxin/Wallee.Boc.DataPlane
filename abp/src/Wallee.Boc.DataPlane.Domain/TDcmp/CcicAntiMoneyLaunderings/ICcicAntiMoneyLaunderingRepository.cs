using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;

/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
public interface ICcicAntiMoneyLaunderingRepository : IUpsertableRepository<CcicAntiMoneyLaundering>
{
}
