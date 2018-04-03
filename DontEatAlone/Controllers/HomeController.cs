using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DontEatAlone.Models;
using DontEatAlone.Data;

namespace DontEatAlone.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult APIDocs()
        {
            ViewData["Title"] = "Public API";
            ViewData["Message"] = "Easy way to do a lot!";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CreateReservation()
        {
           // ViewData["UserType"] = Request.Cookies["UserType"] ?? "regular";
            return View();
        }

        public IActionResult ViewReservations()
        {
            //    var myquery = _context.Reservation.Where(r=>r.Place.Id )

            var query = from p in _context.Place
                        from r in _context.Reservation
                        where r.PlaceID == p.Id
                        select new Place() { Id=p.Id, Address = p.Address, };
            List < Place > places = _context.Place.Select(p => new Place
            {
                Id = p.Id,
                Address = p.Address,
                Name = p.Name,
                Longtitude = p.Longtitude,
                Latitude = p.Latitude,
                Reservations = _context.Reservation.Where(r => r.PlaceID == p.Id).ToList()
            }).ToList();
            IEnumerable<Reservation> reservations = _context.Reservation.Select(r => new Reservation
            {
                Id = r.Id,
                Title = r.Title,
                DateStart = r.DateStart,
                DateEnd = r.DateEnd,
                NumberOfPeople = r.NumberOfPeople,
                Status = r.Status,
                PlaceID = r.PlaceID

            });
            return View(places);
        }

        public IActionResult ReservationPage()
        {
            return View();
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
