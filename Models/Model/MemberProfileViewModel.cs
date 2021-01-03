using Models.Entity;
using System.Collections.Generic;

namespace Models.Model
{
    public class MemberProfileViewModel
    {
        public List<Order> Orders { get; set; }
        public ClientAccount AccountInformation { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
