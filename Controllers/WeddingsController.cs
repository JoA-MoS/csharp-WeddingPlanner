using WeddingPlanner.Data;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models.WeddingViewModels;


namespace Weddings.Controllers
{
    [Authorize]
    [Route("weddings")]
    public class WeddingsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public UserManager<ApplicationUser> UserManager => _userManager;

        public WeddingsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            var userId = _userManager.GetUserId(User);
            List<Wedding> weddings = _context.Weddings.Where(w => w.Date >= DateTime.Now)
                                        .Include(w => w.WeddingGuests).ToList();
            return View("Dashboard", weddings);
        }

        [HttpGet("{weddingId:int}")]
        public IActionResult GetWedding(int weddingId)
        {
            Wedding wedding = _context.Weddings.Where(w => w.WeddingId == weddingId)
                                                            .Include(w => w.WeddingGuests)
                                                                .ThenInclude(wg => wg.Guest)
                                                            .First();

            return View("WeddingDetails", wedding);

        }


        [HttpGet("{weddingId:int}/delete")]
        // [Authorize(Policy = "Over21")]
        public IActionResult DeleteWedding(int weddingId)
        {
            var userId = _userManager.GetUserId(User);
            Wedding wedding = _context.Weddings.Where(w => w.WeddingId == weddingId && w.OwnerId == userId).First();

            if (wedding != null)
            {
                _context.Weddings.Remove(wedding);
                _context.SaveChanges();
            }


            return RedirectToAction("Dashboard");

        }


        [HttpGet("{weddingId:int}/rsvp")]
        public IActionResult JoinWedding(int weddingId)
        {
            var userId = _userManager.GetUserId(User);


            Wedding wedding = _context.Weddings.Where(w => w.WeddingId == weddingId)
                                                            .Include(w => w.WeddingGuests)
                                                            .First();
            if (wedding != null)
            {
                wedding.WeddingGuests.Add(new WeddingGuest
                {
                    GuestId = userId,
                    CreatedById = userId,
                    ModifiedById = userId,
                }
                );
                _context.SaveChanges();
            }


            return RedirectToAction("Dashboard");

        }

        [HttpGet("{weddingId:int}/un-rsvp")]
        public IActionResult LeaveWedding(int weddingId)
        {
            var userId = _userManager.GetUserId(User);


            WeddingGuest weddingGuest = _context.WedddingGuests.Where(wg => wg.WeddingId == weddingId && wg.GuestId == userId).First();
            if (weddingGuest != null)
            {
                _context.WedddingGuests.Remove(weddingGuest);
                _context.SaveChanges();
            }


            return RedirectToAction("Dashboard");

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateWedding");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateWeddingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                Wedding review = new Wedding
                {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    Address = model.Address,
                    OwnerId = userId,
                    CreatedById = userId,
                    ModifiedById = userId
                };
                _context.Weddings.Add(review);
                _context.SaveChanges();
                System.Console.WriteLine("++++++++++++++++++++VALID+++++++++++++++++++");
                return RedirectToAction("Dashboard");
            }
            else
            {
                System.Console.WriteLine("--------------------NOT VALID--------------------");
                return View("CreateWedding", model);
            }
        }

    }
}
