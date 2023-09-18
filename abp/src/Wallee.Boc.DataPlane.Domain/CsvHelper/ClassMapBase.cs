using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;

namespace Wallee.Boc.DataPlane.CsvHelper
{
    public abstract class ClassMapBase<T> : ClassMap<T> where T : class
    {
        protected DateTime? DateTimeConverter(IReaderRow row, int index, string dateFormat, bool required = true)
        {
            var dateString = row.GetField<string>(index);

            DateTime date;

            if (DateTime.TryParseExact(dateString, dateFormat, null, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                if (required)
                {
                    throw new CsvHelperException(row.Context, $"无效日期格式: {dateString}");
                }
                return null;
            }
        }
    }
}
