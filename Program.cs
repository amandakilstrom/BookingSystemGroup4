namespace BookingSystemGroup4
{
    internal class Program
    {
        List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            
        }

        public static void ShowAllBookings()
        {

        }

        public static void UpdateBooking()
        {

        }

        public static void RemoveBooking()
        {

        }

        public static void SearchBooking()
        {
            bool yearHasBookings = false;
            Console.WriteLine("What year of bookings do you wanna see?");
            int choiseYear = int.Parse(Console.ReadLine());
            foreach (var local in locals)
            {
                foreach (var bookings in local.Bookings)
                {

                    if (bookings.StartTime.Year == choiseYear)
                    {
                        yearHasBookings = true;
                        Console.WriteLine($"Room: {bookings.Name}, Boked by {bookings.BookingName} ");
                        Console.WriteLine($"{bookings.StartTime:Y} {bookings.StartTime:t} - {bookings.StartTime.Add(bookings.Duration):t}");
                        Console.WriteLine();

                    }


                }
            }
            if (!yearHasBookings)
            {
                Console.WriteLine($"No bookings were found for the year {choiseYear}.");
            }
            GobackPause();
        }
    }
}
