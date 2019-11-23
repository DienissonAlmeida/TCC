namespace eFlight.Domain.Features.Flights
{
    public class Seat : Entity
    {
        public int Number { get; set; }
        public int FlightId { get; set; }
    }
}