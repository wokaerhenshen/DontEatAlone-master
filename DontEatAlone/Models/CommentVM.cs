using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models
{
    public class CommentVM
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string ProfileImg { get; set; }

    }
}
