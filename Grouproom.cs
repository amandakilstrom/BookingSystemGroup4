


namespace BookingSystemGroup4
{
    internal class Grouproom : Local
    {
        public Grouproom() 
        {
            
        }
        public Grouproom(string name, int seats)
            :base(name, seats) 
        {
            
            Name = name;
            Seats = seats;
            
        }

        public override void BookRoom(string name, DateTime startTime, TimeSpan duration, string bookingName)
        {

            base.BookRoom(name, startTime, duration, bookingName); //kör base class metod
            
        }
        
    }
}

