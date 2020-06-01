using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Cstat.Statistic
{
    public class DiskMetric
    {
        [JsonProperty]
        private string Mount { get; }

        [JsonProperty]
        private string Name { get; }
        
        [JsonProperty]
        private long Available { get; }
        
        [JsonProperty]
        private long Used { get; }

        [JsonProperty]
        private long Total { get; }

        // Mimicking the output of df in the order of constructor
        public DiskMetric(string source, long itotal, long iused, long iavail, string target)
        {
            Mount = target;
            Name = source;
            Available = iavail;
            Used = iused;
            Total = itotal;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
