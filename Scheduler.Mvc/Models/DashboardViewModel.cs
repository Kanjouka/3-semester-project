using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol.Core.Types;

namespace Scheduler.Mvc.Models
{
    public class DashboardViewModel
    {
        [BindNever]
        public IEnumerable<HourSlipView>? HourSlips { get; set; } = null;

        public HourSlipView HourSlip { get; set; }
    }
}