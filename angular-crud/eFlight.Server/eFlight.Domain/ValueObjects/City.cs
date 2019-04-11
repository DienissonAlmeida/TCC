using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; set; }

        public string Country { get; set; }

        public Address(string city, string country)
        {
            City = city;
            Country = country;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return Country;
        }
    }
}
