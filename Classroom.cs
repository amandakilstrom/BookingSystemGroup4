﻿


namespace BookingSystemGroup4
{
    internal class Classroom : Local
    {
        public Classroom()
        {
            
        }
        public Classroom(string name, int seats)
            :base (name, seats) 
        {
            RoomType = "Classroom";
            Name = name;
            Seats = seats;
        }

        public override void BookRoom(string name, DateTime startTime, TimeSpan duration, string bookingName)
        {

            base.BookRoom(name, startTime, duration, bookingName); //kör base class metod

        }
    }
}

