using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Wedding : AuditEntity, IHaveAnOwner
    {
        public int WeddingId { get; set; }
        public string WedderOne { get; set; }

        public string WedderTwo { get; set; }

        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public virtual List<WeddingGuest> WeddingGuests { get; set; } = new List<WeddingGuest>();


        [NotMapped]
        public string Name
        {
            get { return WedderOne + " & " + WedderTwo; }
        }
        [NotMapped]
        public int GuestCount
        {
            get { return WeddingGuests.Count; }
        }
        // [InverseProperty("Owner")]
        // public virtual List<weddingplanner> WeddingPlanner { get; set; } = new List<weddingplanner>();
        // public virtual List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
