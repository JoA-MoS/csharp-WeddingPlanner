using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeddingPlanner.CustomAttributes;

namespace WeddingPlanner.Models.WeddingViewModels
{
    public class CreateWeddingViewModel
    {
        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }

        [Required]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Enter a future date")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Wedding Address")]
        public string Address { get; set; }

    }
}
