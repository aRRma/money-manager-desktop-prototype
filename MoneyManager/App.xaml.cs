﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoneyManager.Contracts.Services;
using MoneyManager.Contracts.Views;
using MoneyManager.Core.Constants;
using MoneyManager.Core.Contracts.Services;
using MoneyManager.Core.DataBase.Config;
using MoneyManager.Core.RegistrationServices;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;
using MoneyManager.Core.Services;
using MoneyManager.Core.Services.AutoRegister;
using MoneyManager.Models;
using MoneyManager.Services;
using MoneyManager.ViewModels;
using MoneyManager.Views;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager;

// For more information about application lifecycle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview

// WPF UI elements use language en-US by default.
// If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
// Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
public partial class App : Application
{
    private string DEF_CONFIG_FILE_NAME = "appsettings.json";

    private IHost _host;
    private IConfiguration _configuration;

    public T? GetService<T>()
        where T : class
        => _host.Services.GetService(typeof(T)) as T;

    public App()
    {
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;

        // Host.CreateDefaultBuilder сам добавляет appsettings.json автоматом
        // Но как вариант так можно подгружать другие конфиги
        //var configBuilder = new ConfigurationBuilder()
        //    .AddJsonFile($"{DEF_CONFIG_FILE_NAME}", optional: false, reloadOnChange: true);
        //_configuration = configBuilder.Build();

        // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
        _host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureAppConfiguration(c =>
            {
                c.SetBasePath(appLocation);
            })
            .ConfigureServices(ConfigureServices)
            .Build();
        await _host.StartAsync();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // конфиг из сервиса или из контекста можно достать
        _configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        // TODO прикрутить валидацию конфигов
        services.Configure<AppConfig>(_configuration.GetSection(nameof(AppConfig)));
        services.Configure<AutoRegisterServicesConfig>(_configuration.GetSection(nameof(AutoRegisterServicesConfig)));
        //services.Configure<DataBaseConfig>(context.Configuration.GetSection(nameof(DataBaseConfig)));


        services.AddOptions<DataBaseConfig>()
            .BindConfiguration(nameof(DataBaseConfig))
            .ValidateDataAnnotations()
            .ValidateOnStart();


        // модный вариант регистрации чтобы отказаться от связи с IOptions в сервисах
        services.AddSingleton(_ => _.GetRequiredService<IOptions<AppConfig>>().Value);
        services.AddSingleton(_ => _.GetRequiredService<IOptions<AutoRegisterServicesConfig>>().Value);
        services.AddSingleton(_ => _.GetRequiredService<IOptions<DataBaseConfig>>().Value);

        // Logger
        services.AddLogging(_ =>
        {
            _.ClearProviders();
            _.AddDebug();
            _.AddConsole();
        });

        // App Host
        services.AddHostedService<ApplicationHostService>();

        // Core Services
        services.AddSingleton<IFileService, FileService>();
        services.AddDatabase();
        
        services.AddRepositories();
        services.AddValidators();

        // Services
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<ISystemService, SystemService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // Views and ViewModels
        services.AddTransient<IShellWindow, ShellWindow>();
        services.AddTransient<ShellViewModel>();

        services.AddTransient<MoneyStorageViewModel>();
        services.AddTransient<MoneyStoragePage>();

        services.AddTransient<SettingsViewModel>();
        services.AddTransient<SettingsPage>();

        // Const provider
        services.AddSingleton<IAppDbExceptionConstantProvider, AppDbExceptionConstantProvider>();

        services.RegisterAutoServices();
        var test0 = services.GetAutoService<SomeTestAutoRegisterService>();
        var test1 = services.GetRequiredAutoService<SomeTestAutoRegisterServiceTwo>();
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        _host = null;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // TODO: Please log and handle the exception as appropriate to your scenario
        // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
    }
}
