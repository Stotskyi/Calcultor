using Calculator.PL.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        
        var uiManager = host.Services.GetRequiredService<UIManager>();
        
        uiManager.DisplayIntroduction();

        while (true)
        {
            uiManager.DisplayActionPage();
        }
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                BuildConfig(config);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton(Log.Logger); 
                services.AddSingleton<UIManager>();
            })
            .UseSerilog((context, loggerConfig) => 
                loggerConfig.ReadFrom.Configuration(context.Configuration));
    private static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}", optional: true)
            .AddEnvironmentVariables();
    }
}