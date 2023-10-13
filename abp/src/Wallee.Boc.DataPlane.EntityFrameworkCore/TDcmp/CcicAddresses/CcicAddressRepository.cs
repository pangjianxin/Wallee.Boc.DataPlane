using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

public class CcicAddressRepository : UpsertableEfCoreRepository<CcicAddress>, ICcicAddressRepository
{
    public CcicAddressRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicAddress>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    
}