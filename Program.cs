using System;
using System.Xml.Linq;

namespace BookingSystemGroup4
{
    internal class Program
    {
        List<Local> locals = new List<Local>();
        public static List<Local> rooms = new List<Local>();


        static void Main(string[] args)
        {
            Program.ShowAllRooms();
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

        public static void ShowAllRooms()
        {
            rooms.Add(new Local("Grupprum A", DateTime.Now, new TimeSpan(1, 0, 0), 6)); 
            rooms.Add(new Local("Grupprum B", DateTime.Now, new TimeSpan(2, 0, 0), 6));
            rooms.Add(new Local("Grupprum C", DateTime.Now, new TimeSpan(3, 0, 0), 6));
            rooms.Add(new Local("Sal A", DateTime.Now, new TimeSpan(1, 0, 0), 50));
            rooms.Add(new Local("Sal B", DateTime.Now, new TimeSpan(2, 0, 0), 50));
            rooms.Add(new Local("Sal C", DateTime.Now, new TimeSpan(3, 0, 0), 50));

            foreach (var room in rooms)
            {
                Console.WriteLine($"Namn: {room.Name}, Starttid: {room.StartTime}, Varaktighet: {room.Duration}, Platser: {room.Seats}");
            }

        }

        public static void CheckRoomName()
        {

        }
    }
}
