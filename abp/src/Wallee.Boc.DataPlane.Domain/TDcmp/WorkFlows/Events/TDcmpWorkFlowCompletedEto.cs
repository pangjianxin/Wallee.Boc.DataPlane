﻿using System;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Events
{
    public class TDcmpWorkFlowCompletedEto
    {
        public DateTime DataDate { get; set; }
        public string CronExpression { get; set; } = default!;
    }
}