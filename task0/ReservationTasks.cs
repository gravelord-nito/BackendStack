using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReservationTask
{
    Task ExecuteAsync();
}

public class BookingRoomTask : IReservationTask
{
    private readonly int roomId;
    private readonly HashSet<int> reservedRooms;

    public BookingRoomTask(int roomId, HashSet<int> reservedRooms)
    {
        this.roomId = roomId;
        this.reservedRooms = reservedRooms;
    }

    public async Task ExecuteAsync()
    {
        await Task.Delay(1000);
        if (reservedRooms.Contains(roomId))
        {
            Console.WriteLine($"Room {roomId} is already booked.");
        }
        else
        {
            reservedRooms.Add(roomId);
            Console.WriteLine($"Room {roomId} has been successfully booked.");
        }
    }
}

public class CancelingRoomTask : IReservationTask
{
    private readonly int roomId;
    private readonly HashSet<int> reservedRooms;

    public CancelingRoomTask(int roomId, HashSet<int> reservedRooms)
    {
        this.roomId = roomId;
        this.reservedRooms = reservedRooms;
    }

    public async Task ExecuteAsync()
    {
        await Task.Delay(2000);
        if (reservedRooms.Contains(roomId))
        {
            reservedRooms.Remove(roomId);
            Console.WriteLine($"Reservation for room {roomId} has been successfully canceled.");
        }
        else
        {
            Console.WriteLine($"Room {roomId} is not currently reserved.");
        }
    }
}

public class CheckingAvailabilityTask : IReservationTask
{
    private readonly int roomId;
    private readonly HashSet<int> reservedRooms;

    public CheckingAvailabilityTask(int roomId, HashSet<int> reservedRooms)
    {
        this.roomId = roomId;
        this.reservedRooms = reservedRooms;
    }

    public async Task ExecuteAsync()
    {
        await Task.Delay(500);
        bool isAvailable = !reservedRooms.Contains(roomId);
        Console.WriteLine($"Room {roomId} is {(isAvailable ? "available" : "not available")}.");
    }
}

public class ReservationManager
{
    private readonly List<IReservationTask> reservationTasks = new List<IReservationTask>();

    public void AddTask(IReservationTask task)
    {
        reservationTasks.Add(task);
    }

    public async Task ProcessTasksAsync()
    {
        foreach (var task in reservationTasks)
        {
            await task.ExecuteAsync();
        }
        reservationTasks.Clear();
    }
}
