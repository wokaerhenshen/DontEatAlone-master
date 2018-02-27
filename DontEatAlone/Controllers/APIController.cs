using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontEatAlone.Data;
using DontEatAlone.Models;
using DontEatAlone.Models.AccountViewModels;
using DontEatAlone.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DontEatAlone.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class APIController : Controller
    {
        ReservationRepository _repository;

        public APIController(ApplicationDbContext context)
        {
            _repository = new ReservationRepository(context);
        }

        [HttpPut]
        [Route("Create")]
        public IActionResult CreateReservation(string title, long dateStart, long dateEnd, int numberOfPeople, string status, string locationID)
        {
            Reservation r = new Reservation();
            r.Title = title;
            r.DateStart = new DateTime(dateStart);
            r.DateEnd = new DateTime(dateEnd);
            r.NumberOfPeople = numberOfPeople;
            r.Status = status;
            r.LocationID = locationID;

            return new OkObjectResult(_repository.CreateReservation(r));
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetReservation(int id)
        {
            return new OkObjectResult(_repository.GetReservation(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllReservations()
        {
            return new OkObjectResult(_repository.GetAllReservations());
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateReservation(int id, string title, long dateStart, long dateEnd, int peopleNumber, string status, string locationID)
        {
            Reservation reservation = new Reservation();
            reservation.Title = title;
            reservation.DateStart = new DateTime(dateStart);
            reservation.DateEnd = new DateTime(dateEnd);
            reservation.NumberOfPeople = peopleNumber;
            reservation.Status = status;
            reservation.LocationID = locationID;

            return new OkObjectResult(_repository.UpdateReservation(reservation));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            return new OkObjectResult(_repository.DeleteReservation(id));
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel model)
        {
            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup(RegisterViewModel model)
        {
            return new OkObjectResult(true);
        }
    }
}