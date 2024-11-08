using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    public class Booking
    {
        public string BookingName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public Booking(string bookingName, DateTime startTime, TimeSpan duration)
        {
            BookingName = bookingName;
            StartTime = startTime;
            Duration = duration;
        }
    }
}
