using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTimeOffset date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonth(DateTimeOffset date);
    }
}
