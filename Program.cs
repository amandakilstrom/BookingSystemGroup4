
﻿using System;
using System.Text.Json;
using System.Xml.Linq;

﻿using Microsoft.VisualBasic;


namespace BookingSystemGroup4
{
    internal class Program
    {

        public static List<Local> locals = new List<Local>();

        static void Main(string[] args)
        {
            string filePath = "Locals.json";

            if (File.Exists(filePath))
            {
                //om filen finns
                string Loadedlocals = File.ReadAllText("Locals.json");
                locals = JsonSerializer.Deserialize<List<Local>>(Loadedlocals);
            }
            else
            {
                //gör en fil
                string emptyJson = JsonSerializer.Serialize(locals);
                File.WriteAllText(filePath, emptyJson);

            }

            locals.Add(new Local("Grupprum A", 6));
            locals.Add(new Local("Grupprum B", 6));
            locals.Add(new Local("Grupprum C", 6));
            locals.Add(new Local("Sal A", 50));
            locals.Add(new Local("Sal B", 50));
            locals.Add(new Local("Sal C", 50));

            bool showMenu = true;
            do
            {

                Console.WriteLine("Welcome to room booking");
                Console.WriteLine("Choose an option:\n");
                Console.WriteLine("1 - Show bookings");
                Console.WriteLine("2 - Update booking");
                Console.WriteLine("3 - Remove booking");
                Console.WriteLine("4 - Search booking");
                Console.WriteLine("5 - Show rooms");
                Console.WriteLine("6 - Book room");
                Console.WriteLine("7 - Create room");
                Console.WriteLine("8 - Exit program\n");
                Console.Write("Välj ett alternativ: ");

                Int32.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        ShowAllBookings();
                        break;

                    case 2:
                        UpdateBooking();
                        break;

                    case 3:
                        RemoveBooking();
                        break;

                    case 4:
                        SearchBooking();
                        break;

                    case 5:
                        ShowAllRooms();
                        break;
                    
                    case 6:
                        BookRoom();
                        break;

                    case 7:
                        CreateRoom();
                        break;
                    
                    case 8:
                        showMenu = false;
                        break;

                    default:
                    Console.WriteLine("Incorrect input, try again.");
                        break;
                        

                }
            }
            while (showMenu);
        }
        

        public static void ShowAllBookings()

        {

            foreach (var local in locals)
            {
                foreach (var booking in local.Bookings)
                {
                    Console.WriteLine($"Room: {booking.Name} booked by {booking.BookingName}. {booking.StartTime:D}, {booking.StartTime:t} - {booking.StartTime.Add(booking.Duration):t}");


                }
            }
            GobackPause();


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
            foreach (Local local in locals)
            {

                foreach (Local booking in local.Bookings)
                {
                    // Om användarens sökning stämmer in på ett datum i listan
                    if (userDateSearch == booking.StartTime)
                    {
                        Console.Write("Enter new date (yyyy-mm-dd): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime newDate);


                        Console.Write("Enter new duration time: ");
                        TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newDuration);

                        Console.Write("Enter booking name: ");
                        String? bookingName = Console.ReadLine();

                        // Updaterar användarens bokning

                        booking.StartTime = newDate;
                        booking.Duration = newDuration;
                        booking.Name = bookingName;


                        Console.WriteLine("Update is complete");
                        GobackPause();
                        return;
                    }
                }
                
            }
            // Meddelar användaren att den sökta bokningen inte hittades
            Console.WriteLine("Booking was not found");
            GobackPause();
        }

        public static void RemoveBooking()
        {
            // Frågar användaren om bokningens datum
            Console.Write("Please enter the date of the booking you want to remove (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime searchDate);
            int i = 0;
            foreach (Local local in locals)
            {
                foreach (var bookings in local.Bookings)
                {
                    // Om en bokning matchar användarens sökning
                    if (bookings.Bookings[i].StartTime == searchDate)
                    {
                        // Bokningen tas bort
                        bookings.Bookings.Remove(bookings.Bookings[i]);
                        // Går ur metoden
                        GobackPause();
                        return;
                    }
                    i++;
                }
            }
            // Ger ett meddelande till användaren om bokningen inte hittades
            Console.WriteLine("Your booking was not found");
            GobackPause();
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


        public static void ShowAllRooms()
        {
           

            foreach (var local in locals)
            {
                Console.WriteLine($"Namn: {local.Name},Platser: {local.Seats}");
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
        } 
        private static void GobackPause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
            Console.Clear();

        } //wait for key

        public static void CreateRoom()
        {
            // Fråga användaren om namnet på salen och lagra det i variabeln 'roomName'
            Console.Write("Enter the name of the room: ");
            string roomName = Console.ReadLine();

            // Fråga användaren om antalet platser i salen och kontrollera att inmatningen är giltig
            Console.Write("Enter the number of seats for the room: ");
            int seatCount;
            while (!int.TryParse(Console.ReadLine(), out seatCount) || seatCount <= 0)
            {
                // Om inmatningen inte är ett positivt heltal, visa ett felmeddelande och be om en ny inmatning
                Console.WriteLine("Please enter a valid, positive integer for the number of seats.");
            }

            // Skapa ett nytt 'Local'-objekt för salen med det angivna namnet och antalet platser
            // och lägg till det nya rummet i listan 'rooms'
            locals.Add(new Local(roomName, seatCount));

            // Bekräfta för användaren att den nya salen har skapats med det angivna namnet och antalet platser
            Console.WriteLine($"New room '{roomName}' has been created with {seatCount} seats.");
            GobackPause();
        }
    }
}
