using Cstat.Commands;
using Cstat.Options;
using CommandLine;

namespace Cstat
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<MetricOption>(args).WithParsed(o =>
                {
                    switch (o.Metric)
                    {
                        case "cpu":
                            var command = new CpuCommand();
                            command.Execute();
                            break;
                        case "ram":
                            var ram = new RamCommand();
                            ram.Execute();
                            break;
                        case "disk":
                            var disk = new DiskCommand();
                            disk.Execute();
                            break;
                    }
                });
        }
    }
}
