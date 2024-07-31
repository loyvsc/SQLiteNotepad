using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddConfigurationHostBuilderExtensions
{
    public static IHostBuilder AddConfiguration(this IHostBuilder host)
    {
        host.ConfigureAppConfiguration((config) =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            config.AddEnvironmentVariables();
        });

        return host;
    }
}