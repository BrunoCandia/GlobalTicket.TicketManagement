using GlobalTicket.TicketManagement.App.Contracts;
using GlobalTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GlobalTicket.TicketManagement.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public ICollection<CategoryEventsViewModel> Categories { get; set; } = new List<CategoryEventsViewModel>();

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if ((bool)args.Value)
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
            }
            else
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
            }
        }
    }
}
