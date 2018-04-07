using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DontEatAlone.Models;
using DontEatAlone.Data;
using DontEatAlone.Repo;
using Microsoft.AspNetCore.Identity;

namespace DontEatAlone.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        ReservationRepository rr;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.rr = new ReservationRepository(context);
            _userManager = userManager;
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

        [HttpPost]
        public void createReservation(string title,string placeId, string placeName, string placeAddress,string placeLat,string placeLng,  string date, string startTime, string endTime, string numberPeople,
           string sexString, string ageString,string cuisineType, bool smoke,bool pet,bool alcohol,string languages,string description)
        {
            // ViewData["UserType"] = Request.Cookies["UserType"] ?? "regular";
            string startString = date + " " + startTime;
            string endString = date + " " + endTime;
            DateTime startDate = DateTime.ParseExact(startString, "yyyy-MM-dd HH:mm", null);
            DateTime endDate = DateTime.ParseExact(endString, "yyyy-MM-dd HH:mm", null);
            string userID = _userManager.GetUserId(User);
            if (!rr.placeIdExist(placeId))
            {
                Place place = new Place()
                {
                    Id = placeId,
                    Latitude = Convert.ToDouble(placeLat),
                    Longtitude = Convert.ToDouble(placeLng),
                    Name = placeName,
                    Address = placeAddress
                };
                _context.Place.Add(place);
                _context.SaveChanges();

            }


            Reservation reservation = new Reservation()
            {
                Id = rr.GenerateReservationId(),
                Title = title,
                DateStart = startDate,
                DateEnd = endDate,
                NumberOfPeople = Int32.Parse(numberPeople),
                Status = "open",
                PlaceID = placeId,
                UserId = userID
            };
            rr.CreateReservation(reservation);

            UserReservation userReservation = new UserReservation()
            {
                UserID = userID,
                ReservationID = reservation.Id
            };
            _context.SaveChanges();

            Limitations limitations = new Limitations()
            {
                Id = reservation.Id,
                Gender = sexString,
                CuisineType = cuisineType,
                Age = ageString,
                Smoking = smoke,
                Pets = pet,
                Alcohol = alcohol,
                Languages = languages,
                Description = description

            };

            _context.Limitations.Add(limitations);
            _context.SaveChanges();


        }

        public IActionResult CreateReservation()
        {
            // ViewData["UserType"] = Request.Cookies["UserType"] ?? "regular";
            return View();
        }

        public IActionResult ViewReservations()
        {
            List <Place> places = _context.Place.Select(p => new Place
            {
                Id = p.Id,
                Address = p.Address,
                Name = p.Name,
                Longtitude = p.Longtitude,
                Latitude = p.Latitude,
                Reservations = _context.Reservation.Where(r => r.PlaceID == p.Id).ToList()
            }).ToList();
            List<ReservationViewModel> reservations = _context.Reservation.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                Title = r.Title,
                DateStart = r.DateStart,
                DateEnd = r.DateEnd,
                NumberOfPeople = r.NumberOfPeople,
                Status = r.Status,
                LocationAddress = _context.Place.Where(p => p.Id == r.PlaceID).FirstOrDefault().Address,
                AuthorName = _context.ApplicationUser.Where(au => au.Id == r.UserId).FirstOrDefault().UserName
            }).ToList();
            PlaceReservationViewModel model = new PlaceReservationViewModel()
            {
                Reservations = reservations,
                Places = places
            };
            return View(model);
        }

        public IActionResult ReservationPage(int id)
        {
            Reservation reservation = rr.GetReservation(id);
            ViewBag.id = id;
            ViewBag.name = rr.getLocationNameByReservationId(id);
            ViewBag.address = rr.getAddressByReservationId(id);
            ViewBag.limitations = rr.getLimitationByReservationId(id);
            return View(reservation);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
