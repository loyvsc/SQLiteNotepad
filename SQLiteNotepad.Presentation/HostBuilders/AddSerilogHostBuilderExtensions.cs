using Microsoft.Extensions.Hosting;
using Serilog;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddSerilogHostBuilderExtensions
{
    public static IHostBuilder AddSerilog(this IHostBuilder host)
    {

        return host
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration);
            });
    }
}