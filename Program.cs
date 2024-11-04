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
            // Frågar användaren om bokningens datum
            Console.Write("Please enter the date of the booking you want to remove (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime searchDate);

            // Går igenom alla bokningar i listan
            for (int i = 0; i < Local.Bookings.Count; i++)
            {
                // Om en bokning matchar användarens sökning
                if (Local.Bookings[i].StartTime == searchDate)
                {
                    // Bokningen tas bort
                    Local.Bookings.Remove(Local.Bookings[i]);
                    // Går ur metoden
                    return;
                }
            }
            // Ger ett meddelande till användaren om bokningen inte hittades
            Console.WriteLine("Your booking was not found");
        }

        public static void SearchBooking()
        {

        }
    }
}
