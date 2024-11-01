using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    internal class Local : IBookable
    {
        public List<Local> Bookings { get; set; } = new List<Local>();
        public String Name { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Seats { get; set; }

        public Local()
        {

        }
        public Local(string name, DateTime startTime, TimeSpan duration)
        {
            Name = name;
            StartTime = startTime;
            Duration = duration;
            
        }
        public virtual void BookRoom(string name, DateTime startTime, TimeSpan duration) //Testar att boka rummet 
        {
            
            foreach (var booking in Bookings) //loppar igenom alla befintliga bokningar
            {
                if (Booked(booking.StartTime, booking.Duration, startTime, duration)) //kollar om bokningen finns redan
                {
                    Console.WriteLine($"Bokningen den {startTime:dd MMM yyyy} kl. {startTime:HH:mm}, i {duration.Hours} h och {duration.Minutes} min, kan tyvärr inte genomföras eftersom tiden är upptagen."); //skriver ut fel medelande om man inte kan boka
                    return;
                }
            }
            Local newBooking = new Local(name, startTime, duration); //gör bookningen
            Bookings.Add(newBooking); //lägger till den i listan
            Console.WriteLine($"Bokningen lyckades! {startTime:dd MMM yyyy} kl. {startTime:HH:mm} till {startTime.Add(duration):HH:mm}."); //skriver ut meddelande om lyckas boka
        }

        private bool Booked(DateTime oldStartTime, TimeSpan oldDuration, DateTime newStartTime, TimeSpan newDuration) //kollar om tiden är upptagen
        {
            DateTime oldEndTime = oldStartTime + oldDuration; //Bokad tid slut
            DateTime newEndTime = newStartTime + newDuration; //new bokning tid slut

            return newStartTime < oldEndTime && newEndTime > oldStartTime; //return om newStartTime startar före oldEndTime är slut och om newEndtime överlappar oldStartTime
        }

        
    }

}
