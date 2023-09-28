using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

/// <summary>
/// 客户机构调整
/// </summary>
public interface ICusOrgAdjusmentRepository : IRepository<CusOrgAdjusment>
{
    Task UpsertAsync(IEnumerable<CusOrgAdjusment> convertedCuses);
}
