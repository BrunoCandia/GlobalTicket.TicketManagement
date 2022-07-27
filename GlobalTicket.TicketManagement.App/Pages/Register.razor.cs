using GlobalTicket.TicketManagement.App.Contracts;
using GlobalTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GlobalTicket.TicketManagement.App.Pages
{
    public partial class Register
    {

        public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public string Message { get; set; } = null!;

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; } = null!;

        public Register()
        {
        }

        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.Register(RegisterViewModel.FirstName, RegisterViewModel.LastName, RegisterViewModel.UserName, RegisterViewModel.Email, RegisterViewModel.Password);

            if (result)
            {
                NavigationManager.NavigateTo("home");
            }

            Message = "Something went wrong, please try again.";
        }
    }
}
