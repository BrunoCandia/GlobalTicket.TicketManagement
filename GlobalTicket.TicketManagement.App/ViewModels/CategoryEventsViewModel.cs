namespace GlobalTicket.TicketManagement.App.ViewModels
{
    public class CategoryEventsViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<EventNestedViewModel> Events { get; set; } = new List<EventNestedViewModel>();
    }
}
