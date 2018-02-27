using DontEatAlone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Repo
{
    public class CommentRepository
    {
        ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetAllComments()
        {
            return _context.Comment.ToList();
        }

        public List<Comment> GetAllCommentsByReservation(int reservationId)
        {
            return _context.Comment.Where(c => c.ReservationID == reservationId).ToList();
        }

        public bool UpdateComment(Comment newComment)
        {
            Comment comment = _context.Comment.Where(c => c.Id == newComment.Id).FirstOrDefault();
            if (comment != null)
            {
                comment.Body = newComment.Body;
                comment.Date = newComment.Date;
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteComment(int id)
        {
            Comment comment = _context.Comment.Where(c => c.Id == id).FirstOrDefault();
            if (comment != null)
            {
                _context.Remove(comment);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool CreateComment(Comment comment)
        {
            if (comment != null)
            {
                _context.Comment.Add(comment);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
