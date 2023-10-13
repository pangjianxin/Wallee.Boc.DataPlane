using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

/// <summary>
/// 对公客户类别信息    a08
/// </summary>
public interface ICcicCustomerTypeRepository : IUpsertableRepository<CcicCustomerType>
{
}
