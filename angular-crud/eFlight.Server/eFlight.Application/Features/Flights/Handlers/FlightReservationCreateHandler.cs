using eFlight.Application.Features.Flights.Commands;
using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights.Handlers
{
    public class FlightReservationCreateHandler : IRequestHandler<FlightReservationRegisterCommand, bool>
    {
        private readonly IFlightReservationRepository _flightReservationRepository;

        public FlightReservationCreateHandler(IFlightReservationRepository repository)
        {
            _flightReservationRepository = repository;
        }

        public async Task<bool> Handle(FlightReservationRegisterCommand request, CancellationToken cancellationToken)
        {
            var flight = _flightReservationRepository.GetAllIncludeFlight().Result.Select(x => x.Flight).Where(x => x.Id == request.FlightId).First();

            var flightReservation = new FlightReservation()
            {
                FlightId = request.FlightId,
                Flight = flight,
                InputDate = request.Date,
                OutputDate = request.Return,
                Description = request.Description,
                FlightReservationCustomers = new List<Customer>()
            };

            if (request.CustomerRegisterCommand != null)
            {
                foreach (var customer in request.CustomerRegisterCommand)
                {
                    flightReservation.FlightReservationCustomers.Add(new Customer()
                    {
                        Name = customer.Name,
                        LastName = customer.LastName,
                        Sex = customer.Sex
                    });
                }
            }
            var result = flightReservation.CanRegister();

            if (result == "Cadastro validado")
            {
                await _flightReservationRepository.Add(flightReservation);
                return true;
            }
            return false;
        }
    }
}
