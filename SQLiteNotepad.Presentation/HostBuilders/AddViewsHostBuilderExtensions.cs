using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLiteNotepad.ApplicationCore.Primitives.Interfaces;
using SQLiteNotepad.DAL.Services;
using SQLiteNotepad.Presentation.Views;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddViewsHostBuilderExtensions
{
    public static IHostBuilder AddViews(this IHostBuilder host)
    {
        host.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<MainWindow>();
        });
        return host;
    }
}