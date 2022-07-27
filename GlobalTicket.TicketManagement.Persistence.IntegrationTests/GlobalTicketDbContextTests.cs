using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace GlobalTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GlobalTicketDbContextTests
    {
        private readonly GlobalTicketDbContext _globalTicketDbContext;
        //private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        //private readonly string _loggedInUserId;

        public GlobalTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GlobalTicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            //_loggedInUserId = "00000000-0000-0000-0000-000000000000";
            //_loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            //_loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            //_globalTicketDbContext = new GlobalTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);

            _globalTicketDbContext = new GlobalTicketDbContext(dbContextOptions, null!);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event { 
                EventId = Guid.NewGuid(), 
                Name = "Test event",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTimeOffset.UtcNow.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
            };

            _globalTicketDbContext.Events.Add(ev);

            await _globalTicketDbContext.SaveChangesAsync();

            //ev.CreatedBy.ShouldBe(_loggedInUserId);
            ev.CreatedBy.ShouldBe("System");
        }
    }
}
