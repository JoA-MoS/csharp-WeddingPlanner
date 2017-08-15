using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WeddingPlanner.Models {
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName {
            get { return FirstName + " " + LastName; }
        }

        // [InverseProperty("Owner")]
        // public virtual List<weddingplanner> WeddingPlanner { get; set; } = new List<weddingplanner>();
        // public virtual List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
