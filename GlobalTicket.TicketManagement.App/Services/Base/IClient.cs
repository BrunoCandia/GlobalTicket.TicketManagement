using System.Net.Http;

namespace GlobalTicket.TicketManagement.App.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
