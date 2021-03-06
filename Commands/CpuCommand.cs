using System;
using System.Diagnostics;
using Cstat.Metrics;

namespace Cstat.Commands
{
    public class CpuCommand : ICommand
    {

        public void Execute()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
    
            var endTime = DateTime.UtcNow;
            
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            
            var cpuStatistic = new CpuMetric(cpuUsageTotal, Environment.ProcessorCount);
            Console.WriteLine(cpuStatistic.ToString());
        }
        
    }
}
