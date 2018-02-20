using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Data
{
    public class Initialize
    {
        private ApplicationDbContext _context;
        public Initialize(ApplicationDbContext context)
        {
            _context = context;
            InitializeData();
        }

        public void InitializeData()
        {
           if (_context.User.Count() == 0)
            {
                
            }
        }
    }
}
