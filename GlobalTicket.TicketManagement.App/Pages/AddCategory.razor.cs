using GlobalTicket.TicketManagement.App.Contracts;
using GlobalTicket.TicketManagement.App.Services;
using GlobalTicket.TicketManagement.App.Services.Base;
using GlobalTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.App.Pages
{
    public partial class AddCategory
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public CategoryViewModel CategoryViewModel { get; set; } = null!;

        public string Message { get; set; } = null!;

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CategoryDataService.CreateCategory(CategoryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CategoryDto> response)
        {
            if (response.Success)
            {
                Message = "Category added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
