using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Cstat.Statistic;
using Newtonsoft.Json;

namespace Cstat.Commands
{
    public class DiskCommand : ICommand
    {

        public void Execute()
        {

            var diskFree = ReadDiskFree();
            var infos = new List<DiskMetric>();
            const string pattern = @"[\S]+";

            foreach (var line in diskFree.Split("\n"))
            {
                if (line.StartsWith("Filesystem"))
                {
                    continue;
                }

                var matches = Regex.Matches(line, pattern);

                if (matches.Count == 0)
                {
                    continue;
                }

                try
                {

                    var metric = new DiskMetric(
                        matches[0].ToString(),
                        long.Parse(matches[1].ToString()),
                        long.Parse(matches[2].ToString()),
                        long.Parse(matches[3].ToString()),
                        matches[4].ToString()
                    );

                    infos.Add(metric);

                } catch (FormatException _exception)
                { }
            }

            Console.WriteLine(JsonConvert.SerializeObject(infos));
        }

        private string ReadDiskFree()
        {
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "/bin/bash";
            p.StartInfo.Arguments = "-c \"df --output=source,itotal,iused,iavail,target\"";
            p.Start();
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

    }
}
