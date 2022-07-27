using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTimeOffset eventDate);
    }
}
