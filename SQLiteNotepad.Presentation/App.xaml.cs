using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SQLiteNotepad.Presentation.HostBuilders;
using SQLiteNotepad.Presentation.Views;

namespace SQLiteNotepad.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    public App()
    {
        // if (!CheckerService.IsLaunchedByUpdater())
        // {
        // 	throw new Exception("""Please, launch ProfitForge with "Updater.exe".""");
        // }
		
        RenderOptions.ProcessRenderMode = RenderMode.Default;
        _host = CreateHostBuilder().Build();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args = null)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureLogging(s => s.ClearProviders())
            .AddSerilog()
            .AddConfiguration()
            .AddDatabaseContext()
            .AddServices()
            .AddViewModels()
            .AddViews()
            .AddValidators();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        Window window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}

