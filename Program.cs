namespace BookingSystemGroup4
{
    internal class Program
    {
        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            Grouproom grouproom1 = new Grouproom();
            grouproom1.Name = "grouproom 1";
            Grouproom grouproom2 = new Grouproom();
            grouproom2.Name = "grouproom 2";
            Classroom classroom1 = new Classroom();
            Classroom classroom2 = new Classroom();
            Classroom classroom3 = new Classroom();
            classroom1.Name = "classroom 1";
            classroom2.Name = "classroom 2";
            classroom3.Name = "classroom 3";
            locals.Add(grouproom1);
            locals.Add(grouproom2);
            locals.Add(classroom1);
            locals.Add(classroom2);
            locals.Add(classroom3);


            BookRoom();

            Console.WriteLine("llllllllllllllllllllll");
            Console.WriteLine("Grouproom");
            foreach (var bookings in Grouproom.Bookings)
            {
                Console.WriteLine(bookings.Name);
            }
            Console.WriteLine("Classroom");
            foreach (var bookings in Classroom.Bookings)
            {
                Console.WriteLine(bookings.Name);
            }
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Make a new booking --\n");

                Local selectedRoom = WhatRoomToBook();
                string? name = GetValidName(); //ange namn
                DateTime startTime = GetValidStartTime(name); //ange starttid
                TimeSpan duration = GetValidDuration(name, startTime); //ange längd
                
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Day: {startTime:D}");
                Console.WriteLine($"Time: {startTime:t}-{startTime.Add(duration):t}");

                if (ConfirmNewBooking(name, startTime, duration, selectedRoom))
                {
                    selectedRoom.BookRoom(name, startTime, duration);
                    
                    GobackPause();
                    break;
                }
                else
                {
                    if (CancelNewBooking())
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

        }
        private static Local WhatRoomToBook()
        {
            int i = 1;
            foreach (var room in locals)
            {
                
                Console.WriteLine($"{i} | {room.Name}");
                i++;
            }
            Console.Write("\nWhich room would you like to book? (Enter room name): ");
            string? whatRoomTobook = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(whatRoomTobook))
            {
                foreach (var room in locals)
                {
                    if (whatRoomTobook == room.Name)
                    {
                        return room;
                    }
                }
                Console.WriteLine("Room not found. Please try again.");
            }
            else
            {
                Console.WriteLine("Room name cannot be empty. Please enter a valid room name.");
            }

            return WhatRoomToBook(); //om man skriver in fel

        }
        private static string GetValidName()
        {
            while (true)
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                Console.WriteLine("Name cannot be empty. Please enter your name.");
            }
        } //kollar man man skriver in ett namn
        private static DateTime GetValidStartTime(string name)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.Write("When do you want to start your booking? (Format: yyyy-MM-dd HH:mm): ");
                string? startTimeInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(startTimeInput) && DateTime.TryParse(startTimeInput, out DateTime startTime)) //kollar om det är rätt format
                {
                    return startTime;
                }
                Console.WriteLine("Invalid date and time format. Please use the format yyyy-MM-dd HH:mm.");
            }
        } //kollar om man skriver in datum rätt
        private static TimeSpan GetValidDuration(string name, DateTime startTime)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
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
        private static bool ConfirmNewBooking(string name, DateTime startTime, TimeSpan duration, Local selectedroom)
        {
            while (true)
            {
                Console.WriteLine($"{name}. Do you want to book {selectedroom.Name} on {startTime:dd MMM yyyy} at {startTime:HH:mm} to {startTime.Add(duration):HH:mm}? (y/n)"); 
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
        private static bool CancelNewBooking() //om man vill inte vill göra sin nya bokning
        {
            while (true)
            {
                Console.WriteLine("Are you sure you want to cancel the booking? (y/n)");
                string? yesOrno = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(yesOrno)) //kollar om det är y eller n
                {
                    if (yesOrno.ToLower() == "y" || yesOrno.ToLower() == "yes")
                    {
                        return true;
                    }
                    else if (yesOrno.ToLower() == "n" || yesOrno.ToLower() == "no")
                    {
                        return false;
                    }
                }
                Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
            }
        }
        private static void GobackPause() 
        {
            Console.WriteLine("Press Enter to continue...\n");
            Console.ReadKey();
            
        }
        
    }
}
