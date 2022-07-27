using GlobalTicket.TicketManagement.Application.Models.Mail;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
