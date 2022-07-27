using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.TicketManagement.App.ViewModels
{
    public class EventDetailViewModel
    {
        public Guid EventId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="The name of the event should be 50 characters or less")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Price should be a positive value")]
        public int Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the event should be 50 characters or less")]
        public string Artist { get; set; } = null!;

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")] 
        public string Description { get; set; } = null!;

        [Required] 
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid CategoryId { get; set; }

        public CategoryViewModel Category { get; set; } = new CategoryViewModel();
    }
}
