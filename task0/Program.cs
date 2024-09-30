using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var reservedRooms = new HashSet<int>(); // Tracks reserved rooms
        var reservationManager = new ReservationManager();

        while (true)
        {
            Console.WriteLine("\n--- Hotel Reservation System ---");
            Console.WriteLine("1. Book a room");
            Console.WriteLine("2. Cancel a reservation");
            Console.WriteLine("3. Check room availability");
            Console.WriteLine("4. Execute task list");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "5")
                break;

            Console.Write("Enter room ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId))
            {
                Console.WriteLine("Invalid room ID. Please try again.");
                continue;
            }

            switch (choice)
            {
                case "1":
                    reservationManager.AddTask(new BookingRoomTask(roomId, reservedRooms));
                    break;
                case "2":
                    reservationManager.AddTask(new CancelingRoomTask(roomId, reservedRooms));
                    break;
                case "3":
                    reservationManager.AddTask(new CheckingAvailabilityTask(roomId, reservedRooms));
                    break;
                case "4":
                    await reservationManager.ProcessTasksAsync();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
            }
        }
    }
}
