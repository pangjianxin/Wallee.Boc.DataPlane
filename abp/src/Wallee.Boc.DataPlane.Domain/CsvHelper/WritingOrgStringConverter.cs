using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace Wallee.Boc.DataPlane.CsvHelper
{
    public class WritingOrganizationUnitStringConverter : DefaultTypeConverter
    {
        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is string)
            {
                return $"=\"{value}\""; // 将数据格式化为文本
            }
            return base.ConvertToString(value, row, memberMapData);
        }
    }
}
