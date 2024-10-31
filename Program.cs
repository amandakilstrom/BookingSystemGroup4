namespace BookingSystemGroup4
{
    internal class Program
    {
        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            BookRoom();
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

        }

        public static void BookRoom()
        {
            Local booking = new Local();
            Classroom classroomBooking = new Classroom();
            Grouproom grouproomBooking = new Grouproom();

            Console.WriteLine("-- Make a new booking --");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("When do you want to start your booking? (Format: yyyy-MM-dd HH:mm): ");
            string startTimeInput = Console.ReadLine();
            DateTime startTime;
            if (DateTime.TryParse(startTimeInput, out startTime))
            {
                Console.Write("How long do you want to book? (1h-3h): ");
                string timeDuration = Console.ReadLine();
                TimeSpan duration;
                if (TimeSpan.TryParse(timeDuration, out duration)) 
                { 
                    
                }
                else
                {
                    Console.WriteLine("Invalid date and time format. Please use the format 1,5. (one and a half hour) ");
                }
                
            }
            else
            {
                Console.WriteLine("Invalid date and time format. Please use the format yyyy-MM-dd HH:mm.");
            }


            booking.BookRoom("johan", DateTime.Now, new TimeSpan(2, 0, 0));
            grouproomBooking.BookRoom("johan", DateTime.Now, new TimeSpan(5, 0, 0));
            booking.BookRoom("johan", DateTime.Now, new TimeSpan(3, 0, 0));
            grouproomBooking.BookRoom("johan", DateTime.Now, new TimeSpan(1, 0, 0));
            classroomBooking.BookRoom("johan", new DateTime(2024,12,3), new TimeSpan(6, 0, 0));
            booking.BookRoom("johan", new DateTime(2024, 12, 3), new TimeSpan(6, 0, 0));

            

        }
    }
}
