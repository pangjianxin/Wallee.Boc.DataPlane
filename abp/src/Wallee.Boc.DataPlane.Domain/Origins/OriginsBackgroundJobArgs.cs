using System;

namespace Wallee.Boc.DataPlane.Origins
{
    public abstract class OriginsBackgroundJobArgs
    {
        public DateTime DataDate { get; set; }
        public string Exception { get; set; } = default!;
    }
}
