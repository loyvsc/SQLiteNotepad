using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLiteNotepad.ApplicationCore.Primitives.Interfaces;
using SQLiteNotepad.DAL.Services;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddServicesHostBuilderExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<INoteService, NoteService>();
        });
        return host;
    }
}