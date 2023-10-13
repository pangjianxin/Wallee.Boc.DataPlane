using System;
using Volo.Abp.Domain.Repositories;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;

/// <summary>
/// 对公名称信息    a22
/// </summary>
public interface ICcicNameRepository : IUpsertableRepository<CcicName>
{
}
