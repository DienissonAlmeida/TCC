using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eFlight.Domain.Features.Cars
{
    public class CarReservation : Reservation
    {
        public string Name { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public List<Customer> CarReservationCustomers { get; set; }

        public bool CanDelete()
        {
            TimeSpan difference = InputDate - DateTime.Now;
            double days = difference.TotalDays;

            return days <= 10 ? false : true;
        }
        public string CanRegister()
        {
            var inputDates = Car.CarReservations.Select(x => x.InputDate.Date).ToList();
            var outputdates = Car.CarReservations.Select(x => x.OutputDate.Date).ToList();

            if (inputDates.Any(x => x <= InputDate) && outputdates.Any(y => y >= OutputDate))
                return "Carro já reservado para o periodo";

            return "Cadastro validado";

        }
    }
}
