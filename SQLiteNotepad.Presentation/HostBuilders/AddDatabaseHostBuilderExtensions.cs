using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLiteNotepad.DAL.Database;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddDatabaseHostBuilderExtensions
{
    public static IHostBuilder AddDatabaseContext(this IHostBuilder host)
    {
        host.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<ApplicationContext>();
        });
        return host;
    }
}