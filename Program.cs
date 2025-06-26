using Microsoft.Extensions.Configuration;
using T2.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using T2.Models; // If AppOptions is here
using T2.Services;
public partial class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
        ("appsettings.json", optional: false, reloadOnChange: true).Build();
        Console.WriteLine("HI");
        var services = new ServiceCollection();
        services.AddSingleton<ILibraryService, LibraryService>();
        services.Configure<AppOptions>(config.GetSection("AppOptions"));
        services.AddSingleton<Runner>();
        var provider = services.BuildServiceProvider();
        var ourRunner = provider.GetRequiredService<Runner>();
        ourRunner.Run();
    }
}