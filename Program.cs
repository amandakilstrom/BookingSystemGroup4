namespace BookingSystemGroup4
{
    internal class Program
    {
        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            Local local1 = new Local();

            local1.Name = "Rum";
            local1.Seats = 30;

            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = TimeSpan.FromHours(2);

            Local booking = new Local();

            booking.Name = "Rum";
            booking.Seats = 30;
            booking.StartTime = dateTime;
            booking.Duration = timeSpan;

            locals.Add(booking);
            
            ShowAllBookings(locals);
        }

        // En metod som tar in en lista
        public static void ShowAllBookings(List<Local> locals)
        {
            // En foreach som går igenom alla objekt i Locals
            foreach (Local local1 in locals)
            {
                // Skriver ut namnet på rummet
                Console.WriteLine($"Room: {local1.Name}");
                // Gör så att Bookings får tillgång till locals
                Local.Bookings = locals;
                // En foreach som går igenom alla objekt i Bookings
                foreach (Local local in Local.Bookings)
                {
                    // Skriver ut datum och tid
                    Console.WriteLine($"Start time: {local.StartTime}\tDuration: {local.Duration}");
                }
            }
        }

        public static void UpdateBooking()
        {

        }

        public static void RemoveBooking()
        {

        }

        public static void SearchBooking()
        {

        }
    }
}
