using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Data;

public interface IDataPlaneDbSchemaMigrator
{
    Task MigrateAsync();
}
