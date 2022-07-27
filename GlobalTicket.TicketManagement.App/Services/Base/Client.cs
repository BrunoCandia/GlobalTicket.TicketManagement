using System.Net.Http;

namespace GlobalTicket.TicketManagement.App.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
