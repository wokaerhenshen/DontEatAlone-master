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

//test
namespace DontEatAlone.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class APIController : Controller
    {
        ReservationRepository _reservationRepo;
        CommentRepository _commentRepo;

        public APIController(ApplicationDbContext context)
        {
            _reservationRepo = new ReservationRepository(context);
            _commentRepo = new CommentRepository(context);
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
            r.PlaceID = locationID;

            return new OkObjectResult(_reservationRepo.CreateReservation(r));
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetReservation(int id)
        {
            return new OkObjectResult(_reservationRepo.GetReservation(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllReservations()
        {
            return new OkObjectResult(_reservationRepo.GetAllReservations());
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
            reservation.PlaceID = locationID;

            return new OkObjectResult(_reservationRepo.UpdateReservation(reservation));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            return new OkObjectResult(_reservationRepo.DeleteReservation(id));
        }

        [HttpGet]
        [Route("GetComments/{id}")]
        public IActionResult GetAllCommentsByReservation(int id)
        {
            return new OkObjectResult(_commentRepo.GetAllCommentsByReservation(id));
        }

        [HttpGet]
        [Route("GetAllComments")]
        public IActionResult GetAllComments()
        {
            return new OkObjectResult(_commentRepo.GetAllComments());
        }

        [HttpPut]
        [Route("UpdateComment")]
        public IActionResult UpdateComment(Comment c)
        {
            return new OkObjectResult(_commentRepo.UpdateComment(c));
        }

        [HttpDelete]
        [Route("DeleteComment")]
        public IActionResult DeleteComment(int id)
        {
            return new OkObjectResult(_commentRepo.DeleteComment(id));
        }

        [HttpPut]
        [Route("CreateComment")]
        public IActionResult CreateComment(Comment c)
        {
            return new OkObjectResult(_commentRepo.CreateComment(c));
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