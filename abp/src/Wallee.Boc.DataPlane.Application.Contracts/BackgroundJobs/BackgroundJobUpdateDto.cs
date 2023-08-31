using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    public class BackgroundJobUpdateDto
    {
        [Required]
        public DateTime NextTryTime { get; set; }
    }
}
