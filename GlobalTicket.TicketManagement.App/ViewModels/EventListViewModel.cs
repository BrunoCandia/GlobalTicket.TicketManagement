namespace GlobalTicket.TicketManagement.App.ViewModels
{
    public class EventListViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
