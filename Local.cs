using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    public class Local : IBookable
    {
        public static List<Local> Rooms = new List<Local>();
        public List<Local> Bookings = new List<Local>();

        public String Name { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Seats { get; set; }

        public Local (String name, DateTime starttime, TimeSpan duration, int seats)
        {
            Name = name;
            StartTime = starttime;
            Duration = duration;
            Seats = seats;
        }



        public void BookRoom()
        {
            throw new NotImplementedException();
        }
    }
}
