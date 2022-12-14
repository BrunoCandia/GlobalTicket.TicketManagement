namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Artist { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;
    }
}
