using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GlobalTicket.TicketManagement.Persistence
{
    public class GlobalTicketDbContextFactory : IDesignTimeDbContextFactory<GlobalTicketDbContext>
    {
        public GlobalTicketDbContext CreateDbContext(string[] args)
        {
            var configuration = GetConfiguration();

            return CreateDbContext(configuration);
        }

        public static GlobalTicketDbContext CreateDbContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GlobalTicketDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GlobalTicketTicketManagementConnectionString"), 
                                           opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds));                        

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return new GlobalTicketDbContext(optionsBuilder.Options, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        private static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, true);                        

            return configurationBuilder.Build();
        }
    }
}
