using DependencyInversionSimple;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddTransient<ILogService, DebugLogService>()
    .AddTransient<Logger>();
using var serviceProvider = services.BuildServiceProvider();

var logService = serviceProvider.GetService<Logger>();

logService?.Log("Hello Microsoft.Extensions.DependencyInjection");