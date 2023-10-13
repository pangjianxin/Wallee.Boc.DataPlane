using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

/// <summary>
/// 对公注册信息    a28
/// </summary>
public interface ICcicRegisterRepository : IUpsertableRepository<CcicRegister>
{
}
