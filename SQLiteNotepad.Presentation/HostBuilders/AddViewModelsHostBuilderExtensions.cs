using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLiteNotepad.Presentation.ViewModels;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<MainWindowViewModel>();
        });
        return host;
    }
}