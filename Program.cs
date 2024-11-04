using Microsoft.VisualBasic;

namespace BookingSystemGroup4
{
    internal class Program
    {
        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            UpdateBooking();
        }

        public static void ShowAllBookings()
        {

        }

        public static void UpdateBooking()
        {
            bool validDateFormat = false;
            DateTime userDateSearch;

            // En do while loop som frågar användaren att skriva en ett datum
            // tills korrekt format av datum är inskrivet
            do
            {
                Console.WriteLine("Which booking do you wish to update?");
                Console.Write("Search booking by date (yyyy-mm-dd): ");
                String? searchDate = Console.ReadLine();

                if (DateTime.TryParse(searchDate, out userDateSearch))
                {
                    DateTime.TryParse(searchDate, out userDateSearch);
                    validDateFormat = true;
                }
                else
                {
                    Console.WriteLine("Please enter date in yyyy-mm-dd format");
                }
            }
            while (!validDateFormat);
            
            // Går igenom alla lokaler i bokningar
            foreach (Local local in Local.Bookings)
            {
                // Om användarens sökning stämmer in på ett datum i listan
                if (userDateSearch == local.StartTime)
                {
                    Console.Write("Enter new date (yyyy-mm-dd): ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime newDate);

                    Console.Write("Enter new duration time: ");
                    TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newDuration);

                    Console.Write("Enter booking name: ");
                    String? bookingName = Console.ReadLine();

                    // Updaterar användarens bokning
                    local.StartTime = newDate;
                    local.Duration = newDuration;
                    local.Name = bookingName;

                    Console.WriteLine("Update is complete");
                    return;
                }
            }
            // Meddelar användaren att den sökta bokningen inte hittades
            Console.WriteLine("Booking was not found");
        }

        public static void RemoveBooking()
        {

        }

        public static void SearchBooking()
        {

        }
    }
}
