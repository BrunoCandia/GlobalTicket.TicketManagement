using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.TicketManagement.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required] 
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
