using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    internal class Local : IBookable
    {
        public List<Local> Bookings = new List<Local>();
        public String Name { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Seats { get; set; }

        public void BookRoom()
        {
            throw new NotImplementedException();
        }
    }
}
