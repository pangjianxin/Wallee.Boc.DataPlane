using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Extensions
{
    public static class EntityCreateTableSqlExtensions
    {
        public static async Task<string> GetTableName<T>(this IReadOnlyRepository<T> repository, string? tempTableSuffix = null) where T : AggregateRoot
        {
            var dbContext = await repository.GetDbContextAsync();
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            var tableName = $"{entityType?.GetTableName()}";
            if (tempTableSuffix != null)
            {
                tableName += $"_{tempTableSuffix}";
            }
            return tableName;
        }
        public static async Task<string> GenerateCreateTableScript<T>(this IReadOnlyRepository<T> repository, string tableName) where T : AggregateRoot
        {
            var dbContext = await repository.GetDbContextAsync();
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            //var tableName = $"{entityType?.GetTableName()}_Temp";
            //var schema = entityType?.GetSchema() ?? "dbo";
            var properties = entityType?.GetProperties();
            var primaryKey = entityType?.FindPrimaryKey();

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"CREATE TABLE [{tableName}] (");

            foreach (var property in properties!)
            {
                var columnName = property.GetColumnName();
                var columnType = property.GetColumnType();
                var isNullable = property.IsNullable;

                stringBuilder.AppendLine($"    [{columnName}] {columnType} {(isNullable ? "NULL" : "NOT NULL")},");
            }

            // 添加主键定义
            if (primaryKey != null)
            {
                var primaryKeyColumns = primaryKey.Properties.Select(p => p.GetColumnName());
                var primaryKeyConstraint = $"    CONSTRAINT [PK_{tableName}] PRIMARY KEY ({string.Join(", ", primaryKeyColumns)})";
                stringBuilder.AppendLine(primaryKeyConstraint);
            }

            stringBuilder.AppendLine(");");

            return stringBuilder.ToString();
        }
    }
}
