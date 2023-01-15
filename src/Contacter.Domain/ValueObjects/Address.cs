using ContactHub.Domain.ErrorHandling;
using ContactHub.Domain.SeedWork;

namespace ContactHub.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        private const int MaxLength = 50;

        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Country { get; private set; }

        public Address(string? street, string? city, string? postalCode, string? country)
        {
            if (!string.IsNullOrWhiteSpace(street) && street.Length > MaxLength)
            {
                throw new ContactorException("AddressValidationError", $"Address cannot have more that {MaxLength} characters", nameof(street));
            }

            if (!string.IsNullOrWhiteSpace(city) && city.Length > MaxLength)
            {
                throw new ContactorException("AddressValidationError", $"City cannot have more that {MaxLength} characters", nameof(city));
            }

            if (!string.IsNullOrWhiteSpace(postalCode) && postalCode.Length > MaxLength)
            {
                throw new ContactorException("AddressValidationError", $"PostalCode cannot have more that {MaxLength} characters", nameof(postalCode));
            }

            if (!string.IsNullOrWhiteSpace(country) && country.Length > MaxLength)
            {
                throw new ContactorException("AddressValidationError", $"Country cannot have more that {MaxLength} characters", nameof(country));
            }

            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public Address() { }

        protected override IEnumerable<object?> GetProperties()
        {
            yield return Street;
            yield return City;
            yield return PostalCode;
            yield return Country;
        }
    }
}
