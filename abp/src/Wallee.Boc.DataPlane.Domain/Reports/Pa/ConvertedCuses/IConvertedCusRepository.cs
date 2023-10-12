using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

/// <summary>
/// 折效客户明细
/// </summary>
public interface IConvertedCusRepository : IRepository<ConvertedCus>
{
    Task UpsertAsync(IEnumerable<ConvertedCus> convertedCuses, bool autoSave = false, CancellationToken cancellationToken = default);
}
