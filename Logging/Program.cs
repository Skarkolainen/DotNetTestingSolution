using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Set up dependency injection
var serviceCollection = new ServiceCollection();
serviceCollection.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});

using var serviceProvider = serviceCollection.BuildServiceProvider();

// Get a logger instance
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

// Log some test messages
logger.LogInformation("This is an information log.{1} {0}", "Parameter 1", "param 2");


Console.ReadLine();
// Dummy Program class to satisfy ILogger<Program>
partial class Program {}
