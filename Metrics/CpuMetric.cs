using System;
using Newtonsoft.Json;

namespace Cstat.Metrics
{
    public class CpuMetric
    {
        [JsonProperty]
        private DateTime CreatedAt { get; }
        [JsonProperty]
        private double CpuUsage { get; }

        [JsonProperty]
        private int CpuCount { get; }
        
        public CpuMetric(double cpuUsage, int cpuCount)
        {
            CreatedAt = DateTime.Now;
            CpuUsage = cpuUsage;
            CpuCount = cpuCount;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
