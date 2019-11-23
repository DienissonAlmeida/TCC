using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features
{
    public class CustomerBuilder
    {
        private static Customer _customer;

        public static CustomerBuilder Start()
        {
            _customer = new Customer()
            {
                Name = "Teste",
                LastName = "Teste2",
                Sex = SexEnum.Male,
            };

            return new CustomerBuilder();
        }

        public Customer Build() => _customer;

        public CustomerBuilder WithId(int id)
        {
            _customer.Id = id;
            return this;
        }
        public CustomerBuilder WithName(string name)
        {
            _customer.Name = name;
            return this;
        }
    }
}
