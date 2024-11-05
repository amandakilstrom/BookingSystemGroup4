namespace BookingSystemGroup4
{
    internal class Program
    {
        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {

            
        }

        // En metod som tar in en lista
        public static void ShowAllBookings(List<Local> locals)


            



        }


        public static void ShowAllBookings()

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

        public static void BookRoom()
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Make a new booking --\n");

                Local selectedRoom = WhatRoomToBook();
                string roomName = selectedRoom.Name;
                string? bookingName = GetValidName(); //ange namn
                DateTime startTime = GetValidStartTime(bookingName); //ange starttid
                TimeSpan duration = GetValidDuration(bookingName, startTime); //ange längd


                Console.Clear();
                Console.WriteLine($"Name: {bookingName}");
                Console.WriteLine($"Day: {startTime:D}");
                Console.WriteLine($"Time: {startTime:t}-{startTime.Add(duration):t}");

                if (ConfirmNewBooking(bookingName, startTime, duration, selectedRoom))
                {
                    selectedRoom.BookRoom(roomName, startTime, duration, bookingName); //sätter in bokningen i selected room
                    Console.WriteLine();
                    GobackPause();
                    break;
                }
                else
                {
                    Console.Write("\nCancel booking.");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Console.Clear();
                    Console.WriteLine("Booking cancelled.");
                    GobackPause();
                    break;

                }

            }

        }
        private static Local WhatRoomToBook()
        {
            int i = 1;
            foreach (var room in locals) //loopar igenom alla rum i locals listan
            {

                Console.WriteLine($"{i} | {room.Name}"); //och skriver ut dem
                i++;
            }
            Console.Write("\nWhich room would you like to book? (Enter room name): ");
            string? whatRoomTobook = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(whatRoomTobook)) //om man skriver något
            {
                foreach (var room in locals) //loopar igeom alla rum i locals listan
                {
                    if (whatRoomTobook == room.Name) //om rummet finns
                    {
                        return room; //skicka till backa det rummet 

                    }
                }
                Console.WriteLine("Room not found. Please try again.");
            }
            else
            {
                Console.WriteLine("Room name cannot be empty. Please enter a valid room name.");
            }

            return WhatRoomToBook(); //om man skriver in fel

        } //kollar vilket rum man vill boka
        private static string GetValidName()
        {
            while (true)
            {
                Console.Write("Name: ");
                string? bookingName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(bookingName))
                {
                    return bookingName;
                }
                Console.WriteLine("Name cannot be empty. Please enter your name.");
            }
        } //kollar man man skriver in ett namn
        private static DateTime GetValidStartTime(string bookingName)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Name: {bookingName}");
                Console.Write("When do you want to start your booking? (Format: yyyy-MM-dd HH:mm): ");
                string? startTimeInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(startTimeInput) && DateTime.TryParse(startTimeInput, out DateTime startTime)) //kollar om det är rätt format
                {
                    return startTime;
                }
                Console.WriteLine("Invalid date and time format. Please use the format yyyy-MM-dd HH:mm.");
            }
        } //kollar om man skriver in datum rätt
        private static TimeSpan GetValidDuration(string bookingName, DateTime startTime)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Name: {bookingName}");
                Console.WriteLine($"Date: {startTime:D}");
                Console.Write("How long do you want to book? (e.g., 1:30 for 1 hour 30 minutes): ");
                string? timeDuration = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(timeDuration) && TimeSpan.TryParse(timeDuration, out TimeSpan duration)) //kollar om det är rätt format
                {
                    return duration;
                }
                Console.WriteLine("Invalid duration format. Please use the format H:MM (e.g., 1:30 for one and a half hours).");
            }
        } //kollar om man skriver in tid rätt
        private static bool ConfirmNewBooking(string bookingName, DateTime startTime, TimeSpan duration, Local selectedroom)
        {
            while (true)
            {
                Console.WriteLine($"{bookingName}. Do you want to book {selectedroom.Name} on {startTime:dd MMM yyyy} at {startTime:HH:mm} to {startTime.Add(duration):HH:mm}? (y/n)");
                string? response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response)) //kollar om det y eller n
                {
                    if (response.ToLower() == "y" || response.ToLower() == "yes")
                    {
                        return true;
                    }
                    else if (response.ToLower() == "n" || response.ToLower() == "no")
                    {
                        return false;
                    }
                }
                Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
            }
        } //kollar om man vill göra sin bookning
        //private static bool CancelNewBooking() //om man vill inte vill göra sin nya bokning
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("Are you sure you want to cancel the booking? (y/n)");
        //        string? yesOrno = Console.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(yesOrno)) //kollar om det är y eller n
        //        {
        //            if (yesOrno.ToLower() == "y" || yesOrno.ToLower() == "yes")
        //            {
        //                return true;
        //            }
        //            else if (yesOrno.ToLower() == "n" || yesOrno.ToLower() == "no")
        //            {
        //                return false;
        //            }
        //        }
        //        Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
        //    }
        //}
        private static void GobackPause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();

        } //wait for key

    }
}
