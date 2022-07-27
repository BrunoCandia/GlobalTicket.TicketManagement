namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
    }
}
