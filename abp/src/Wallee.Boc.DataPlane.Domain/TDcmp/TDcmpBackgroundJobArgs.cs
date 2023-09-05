using System;

namespace Wallee.Boc.DataPlane.TDcmp
{
    public abstract class TDcmpBackgroundJobArgs
    {
        public DateTime DataDate { get; set; }
        public string FileName { get; set; } = default!;
        public string Exception { get; set; } = default!;
    }
}
