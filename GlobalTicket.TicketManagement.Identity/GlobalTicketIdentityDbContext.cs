using GlobalTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagement.Identity
{
    public class GlobalTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GlobalTicketIdentityDbContext(DbContextOptions<GlobalTicketIdentityDbContext> options) : base(options)
        {
        }
    }
}
