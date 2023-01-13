﻿using Contacter.Domain.SeedWork;

namespace Contacter.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Country { get; private set; }

        public Address(string street, string city, string postalCode, string country)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public Address() {}

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return PostalCode;
            yield return Country;
        }
    }
}
