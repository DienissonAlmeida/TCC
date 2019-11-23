using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eFlight.Domain.Features.Hotels
{
    public class HotelReservation : Reservation
    {
        public string Description { get; set; }
        public List<Customer> HotelReservationCustomers { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }

        public string CanRegister()
        {

            if (HotelReservationCustomers.Count <= Hotel.AvailableVacancies)
                return "Voo lotado";

            var reservationsByFlight = Hotel.HotelReservations.SelectMany(x => x.HotelReservationCustomers).ToList();

            foreach (var customerByReservationHotel in reservationsByFlight)
            {
                if (HotelReservationCustomers.Any(x => x.Name == customerByReservationHotel.Name))
                    return $"Vaga já cadastrado: {customerByReservationHotel.Name}";
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
