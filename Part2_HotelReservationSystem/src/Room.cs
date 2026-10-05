namespace Part2_HotelReservationSystem;

public class Room
{
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Reservation> Reservations => _reservations;

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public void ChangePrice(decimal newRate)
    {
        if (newRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    public void AddReservation(Reservation reservation)
    {
        if (reservation == null)
            throw new ArgumentNullException(nameof(reservation));

        foreach (var existingReservation in _reservations)
        {
            if (!IsActive(existingReservation))
                continue;

            if (DatesOverlap(
                    existingReservation.CheckInDate,
                    existingReservation.CheckOutDate,
                    reservation.CheckInDate,
                    reservation.CheckOutDate))
            {
                throw new InvalidOperationException(
                    "The room is already booked for the selected dates.");
            }
        }

        _reservations.Add(reservation);
    }

    private static bool IsActive(Reservation reservation)
    {
        return reservation.Status != ReservationStatus.Cancelled &&
               reservation.Status != ReservationStatus.CheckedOut;
    }

    private static bool DatesOverlap(
        DateTime firstCheckIn,
        DateTime firstCheckOut,
        DateTime secondCheckIn,
        DateTime secondCheckOut)
    {
        return firstCheckIn < secondCheckOut &&
               secondCheckIn < firstCheckOut;
    }
}

public enum RoomType
{
    Single,
    Double,
    Suite
}