using GlobalTicket.TicketManagement.App.Components;
using GlobalTicket.TicketManagement.App.Contracts;
using GlobalTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GlobalTicket.TicketManagement.App.Pages
{
    public partial class TicketSales
    {

        [Inject]
        public IOrderDataService OrderDataService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public string SelectedMonth { get; set; } = null!;

        public string SelectedYear { get; set; } = null!;

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        
        public List<string> YearList { get; set; } = new List<string>() { "2020", "2021", "2022" };

        private int? pageNumber = 1;

        private PaginatedList<OrdersForMonthListViewModel> paginatedList = new PaginatedList<OrdersForMonthListViewModel>();

        private IEnumerable<OrdersForMonthListViewModel> ordersList = new List<OrdersForMonthListViewModel>();

        protected async Task GetSales()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var orders = await OrderDataService.GetPagedOrderForMonth(dt, pageNumber.Value, 5);
            paginatedList = new PaginatedList<OrdersForMonthListViewModel>(orders.OrdersForMonth.ToList(), orders.Count, pageNumber.Value, 5);
            ordersList = paginatedList.Items;

            StateHasChanged();
        }

        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }

            pageNumber = newPageNumber;

            await GetSales();

            StateHasChanged();
        }
    }
}