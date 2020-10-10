using Decorator.Core;
using System;

namespace ShardStatistics
{
    public class CloudWatchShardMetrics : IShardMetrics
    {
        public int GetMetricsInPeriod()
        {
            return default;
        }

        public bool WriteMetrics(int count, DateTime timestamp, string metricName)
        {
            return default;
        }
    }
}
