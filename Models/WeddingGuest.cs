using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class WeddingGuest : AuditEntity
    {
        public int WeddingGuestId { get; set; }
        public string GuestId { get; set; }
        public ApplicationUser Guest { get; set; }
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
    }
}
