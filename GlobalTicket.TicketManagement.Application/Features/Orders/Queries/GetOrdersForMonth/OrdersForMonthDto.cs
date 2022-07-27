namespace GlobalTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class OrdersForMonthDto
    {
        public Guid Id { get; set; }
        public int OrderTotal { get; set; }
        public DateTimeOffset OrderPlaced { get; set; }
    }
}