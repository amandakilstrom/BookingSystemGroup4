//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace BookingSystemGroup4
{
    internal class Classroom : Local
    {
        public Classroom()
        {
            Bookings = new List<Local>();
        }

        
        public override void BookRoom(string name, DateTime startTime, TimeSpan duration, string bookingName)
        {

            base.BookRoom(name, startTime, duration, bookingName); //kör base class metod

        }
    }
}

