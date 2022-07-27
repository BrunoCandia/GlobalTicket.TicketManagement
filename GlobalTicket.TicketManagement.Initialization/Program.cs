
using GlobalTicket.TicketManagement.Initialization.Seeding;
using GlobalTicket.TicketManagement.Persistence;
using Microsoft.Extensions.Configuration;

namespace GlobalTicket.TicketManagement.Initialization;

public static class Program
{
    public static async Task Main()
    {
        var configuration = GetConfiguration();

        var globalTicketDbContext = GlobalTicketDbContextFactory.CreateDbContext(configuration);

        await SeedData(globalTicketDbContext);
    }

    private static IConfiguration GetConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, true);        

        configurationBuilder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
        configurationBuilder.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

        return configurationBuilder.Build();
    }

    private static async Task SeedData(GlobalTicketDbContext globalTicketDbContext)
    {
        await Categories.SeedAsync(globalTicketDbContext);
        await Events.SeedAsync(globalTicketDbContext);
        await Orders.SeedAsync(globalTicketDbContext);
    }
}
