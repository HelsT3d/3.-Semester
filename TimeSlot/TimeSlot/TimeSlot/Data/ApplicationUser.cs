using TimeSlot.Models;
using Microsoft.AspNetCore.Identity;



namespace TimeSlot.Data

{
    public class ApplicationUser : IdentityUser
    {
        public List<Booking>? Bookings {  get; set; }
        
    }
}
