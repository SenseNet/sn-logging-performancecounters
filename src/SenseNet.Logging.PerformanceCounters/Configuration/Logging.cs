using System.Diagnostics;
using System.Linq;
using SenseNet.Configuration;

namespace SenseNet.Logging.PerformanceCounters.Configuration
{
    internal class Logging : SnConfig
    {
        private const string SectionName = "sensenet/logging";

        public static bool PerformanceCountersEnabled { get; internal set; } =
            GetValue<bool>(SectionName, "PerformanceCountersEnabled");

        public static CounterCreationDataCollection CustomPerformanceCounters { get; } =
            new CounterCreationDataCollection(GetListOrEmpty<string>(SectionName, "CustomPerformanceCounters").Distinct()
                .Select(cn => new CounterCreationData
                {
                    CounterType = PerformanceCounterType.NumberOfItems32,
                    CounterName = cn
                }).ToArray());
    }
}
