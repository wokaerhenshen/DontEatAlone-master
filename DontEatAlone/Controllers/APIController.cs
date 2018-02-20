using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontEatAlone.Models;
using DontEatAlone.Models.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DontEatAlone.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class APIController : Controller
    {
        [HttpPut]
        [Route("Create")]
        public IActionResult CreateReservation(string title, long dateStart, long dateEnd, int peopleNumber, string status, string locationID)
        {
            return new ObjectResult(
                new ReservationVM()
                {
                    ID = 1,
                    Title = title,
                    DateStart = new DateTime(dateStart),
                    DateEnd = new DateTime(dateEnd),
                    PeopleNumber = peopleNumber,
                    Status = status,
                    LocationID = locationID
                });
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetReservation(int id)
        {
            return new OkObjectResult(new ReservationVM());
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllReservations()
        {
            return new OkObjectResult(new List<ReservationVM>() { new ReservationVM(), new ReservationVM(), new ReservationVM() });
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateReservation(int id, string title, long dateStart, long dateEnd, int peopleNumber, string status, string locationID)
        {
            return new ObjectResult(
                new ReservationVM()
                {
                    ID = id,
                    Title = title,
                    DateStart = new DateTime(dateStart),
                    DateEnd = new DateTime(dateEnd),
                    PeopleNumber = peopleNumber,
                    Status = status,
                    LocationID = locationID
                });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            return new OkObjectResult(true);
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