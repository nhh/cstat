using CommandLine;

namespace Cstat.Options
{
    public class MetricOption
    {

        [Option('h', "healthcheck", Required = false, HelpText = "Set output to verbose messages.")]
        public string Healthcheck { get; set; }
        
        [Option('m', "metric", Required = true, HelpText = "Set output to verbose messages.")]
        public string Metric { get; set; }
        
        [Option('f', "format", Required = false, Default = "json", HelpText = "Set output to verbose messages.")]
        public string Format { get; set; }
        
    }
}
