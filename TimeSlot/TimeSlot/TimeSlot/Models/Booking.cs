using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSlot.Data;

namespace TimeSlot.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUsers { get; set; } = null;

        [Required]
        public string UsersId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [ValidateNever]
        [BindNever]
        public Room Room { get; set; } = null!;
    }
}
