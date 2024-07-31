using System.Reflection;
using Microsoft.Extensions.Hosting;
using FluentValidation;

namespace SQLiteNotepad.Presentation.HostBuilders;

public static class AddValidatorsHostBuilderExtensions
{
    public static IHostBuilder AddValidators(this IHostBuilder host)
    {
        host.ConfigureServices((hostContext, services) =>
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });
        return host;
    }
}