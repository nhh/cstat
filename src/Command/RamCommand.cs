using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Cstat.Command
{
    public class RamCommand
    {

        public void Execute()
        {
            var meminfo = File.ReadAllText("/proc/meminfo");
            
            var memoryInfo = new Dictionary<string, Int64>();

            foreach (var line in meminfo.Split("\n"))
            {
                var entry = line.Trim()
                    .Replace(" kB", "")
                    .Replace(" ", "")
                    .Split(":");
                
                if (entry.Length == 0 || entry.Length == 1)
                {
                    continue;
                }
                
                // converting kilobytes in megabytes
                memoryInfo.Add(entry[0], Int64.Parse(entry[1]) / 1024);
            }
            
            Console.WriteLine(JsonConvert.SerializeObject(memoryInfo));
        }
        
    }
}