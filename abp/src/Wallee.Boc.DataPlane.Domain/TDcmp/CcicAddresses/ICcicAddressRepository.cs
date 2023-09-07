using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

public interface ICcicAddressRepository : IRepository<CcicAddress>
{
    Task ExecuteSqlRawAsync(string sql);
}
