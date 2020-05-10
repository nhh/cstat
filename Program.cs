using CommandLine;
using Cstat.Command;
using Cstat.Option;

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
                    }
                });
        }
    }
}
