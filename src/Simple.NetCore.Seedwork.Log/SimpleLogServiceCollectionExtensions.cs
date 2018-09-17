using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SimpleLogServiceCollectionExtensions
    {
        public static void AddSimpleNLog(
            this ILoggingBuilder builder,
            IConfiguration configuration, 
            string defaultLoggingConfigKey = "Logging",
            string defaultLogConfigFileName = "nlog.config")
        {
            builder.AddConfiguration(configuration.GetSection(defaultLoggingConfigKey));
            builder.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            NLog.LogManager.LoadConfiguration(defaultLogConfigFileName);
        }
    }
}
