using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace Wallee.Boc.DataPlane.CsvHelper
{
    public class WritingDateTimeConverter : DefaultTypeConverter
    {
        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-dd"); // 你可以在这里指定你想要的日期格式
            }
            return base.ConvertToString(value, row, memberMapData);
        }
    }
}
