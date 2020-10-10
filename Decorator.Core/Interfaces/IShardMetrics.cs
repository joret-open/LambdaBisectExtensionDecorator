using System;

namespace Decorator.Core
{
    public interface IShardMetrics
    {
        int GetMetricsInPeriod();
        bool WriteMetrics(int count, DateTime timestamp, string metricName);
    }
}