using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthVm>
    {
        public DateTimeOffset Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
