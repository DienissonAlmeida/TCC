using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Cars.Queries
{
    public class CarLoadAllQuery : IRequest<List<Car>>
    {
    }
}
