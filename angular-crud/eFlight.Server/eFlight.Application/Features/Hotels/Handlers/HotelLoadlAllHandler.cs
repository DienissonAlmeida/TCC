using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Hotels.Handlers
{
    class HotelLoadlAllHandler : IRequestHandler<HotelLoadAllQuery, List<Hotel>>
    {
        private readonly IRepositoryBase<Hotel> _repository;
        public HotelLoadlAllHandler(IRepositoryBase<Hotel> hotelRepository)
        {
            _repository = hotelRepository;
        }

        public Task<List<Hotel>> Handle(HotelLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
