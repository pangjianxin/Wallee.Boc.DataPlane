﻿using System;

namespace Wallee.Boc.DataPlane.TDcmp
{
    public abstract class TDcmpBackgroundJobArgs
    {
        public Guid WorkFlowId { get; set; }
        public string Exception { get; set; } = default!;
    }
}