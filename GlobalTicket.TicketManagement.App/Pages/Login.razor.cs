using GlobalTicket.TicketManagement.App.Contracts;
using GlobalTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GlobalTicket.TicketManagement.App.Pages
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
        
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public string Message { get; set; } = null!;

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; } = null!;

        public Login()
        {            
        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            if (await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("home");
            }

            Message = "Username/password combination unknown";
        }
    }
}
