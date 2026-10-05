namespace Part2_HotelReservationSystem;

class Program
{
    static void Main(string[] args)
    {
        var guest = new Guest(
            1,
            "Ahmed Ali",
            "01012345678");

        var room = new Room(
            101,
            RoomType.Double,
            1500);

        var reservation = new Reservation(
            1,
            new DateTime(2026, 10, 10),
            new DateTime(2026, 10, 13),
            room);

        guest.AddReservation(reservation);

        Console.WriteLine($"Guest: {guest.FullName}");
        Console.WriteLine($"Phone: {guest.PhoneNumber}");
        Console.WriteLine($"Room: {room.RoomNumber}");
        Console.WriteLine($"Room Type: {room.RoomType}");
        Console.WriteLine($"Nightly Rate: {room.NightlyRate}");
        Console.WriteLine($"Check-in: {reservation.CheckInDate:dd/MM/yyyy}");
        Console.WriteLine($"Check-out: {reservation.CheckOutDate:dd/MM/yyyy}");
        Console.WriteLine($"Status: {reservation.Status}");
        Console.WriteLine($"Total Cost: {reservation.TotalCost}");

        Console.WriteLine();

        reservation.Confirm();

        Console.WriteLine(
            $"Status after confirmation: {reservation.Status}");

        reservation.CheckIn();

        Console.WriteLine(
            $"Status after check-in: {reservation.Status}");

        reservation.CheckOut();

        Console.WriteLine(
            $"Status after check-out: {reservation.Status}");
        
        Console.WriteLine();
        Console.WriteLine("Testing invalid check-out date...");

        try
        {
            var invalidReservation = new Reservation(
                2,
                new DateTime(2026, 10, 15),
                new DateTime(2026, 10, 10),
                room);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Testing invalid room price...");

        try
        {
            room.ChangePrice(-500);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Testing room maintenance...");

        room.StartMaintenance();

        Console.WriteLine($"Room under maintenance: {room.IsUnderMaintenance}");

        try
        {
            var maintenanceReservation = new Reservation(
                3,
                new DateTime(2026, 11, 1),
                new DateTime(2026, 11, 5),
                room);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        room.EndMaintenance();

        Console.WriteLine($"Room under maintenance: {room.IsUnderMaintenance}");

        Console.WriteLine();
        Console.WriteLine("Testing double booking...");

        try
        {
            var secondReservation = new Reservation(
                4,
                new DateTime(2026, 10, 11),
                new DateTime(2026, 10, 14),
                room);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Testing invalid status transition...");

        var statusTestReservation = new Reservation(
            5,
            new DateTime(2026, 12, 1),
            new DateTime(2026, 12, 5),
            room);

        try
        {
            statusTestReservation.CheckIn();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Testing invalid cancellation...");

        try
        {
            reservation.Cancel();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}