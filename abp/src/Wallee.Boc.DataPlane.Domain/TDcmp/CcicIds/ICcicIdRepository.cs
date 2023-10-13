using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;

/// <summary>
/// 对公证件信息    a20
/// </summary>
public interface ICcicIdRepository : IUpsertableRepository<CcicId>
{
}
