using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Globalization;

namespace Wallee.Boc.DataPlane.CsvHelper
{
    public class ReadingDateTimeConverter : DefaultTypeConverter
    {
        private readonly string _dateFormat;

        public ReadingDateTimeConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            DateTime dt;
            if (DateTime.TryParseExact(text, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return dt;
            }
            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
