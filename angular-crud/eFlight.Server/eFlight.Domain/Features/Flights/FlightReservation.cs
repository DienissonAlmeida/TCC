using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eFlight.Domain.Features.Flights
{
    public class FlightReservation : Reservation
    {
        public FlightReservation()
        {
            FlightReservationCustomers = new List<Customer>();
        }

        public string Description { get; set; }
        public IList<Customer> FlightReservationCustomers { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }

        public string CanRegister()
        {

            if (FlightReservationCustomers.Count >= Flight.AvailableVacancies)
                return "Voo lotado";

            var reservationsByFlight = Flight.FlightReservations.SelectMany(x => x.FlightReservationCustomers).ToList();

            foreach (var customerByReservationFlight in reservationsByFlight)
            {
                if (FlightReservationCustomers.Any(x => x.Name == customerByReservationFlight.Name))
                    return $"Vaga já cadastrado: {customerByReservationFlight.Name}";
            }

            return "Cadastro validado";
        }

        public bool CanDelete()
        {
            TimeSpan difference = InputDate - DateTime.Now;
            double days = difference.TotalDays;

            return days <= 10 ? false : true;
        }
    }
}
