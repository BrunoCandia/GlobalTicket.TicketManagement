namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<CategoryEventDto> Events { get; set; } = new List<CategoryEventDto>();
    }
}
