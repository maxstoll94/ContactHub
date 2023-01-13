
using Contacter.Domain.Exceptions;
using Contacter.Domain.SeedWork;
using System.Diagnostics.Metrics;
using System.IO;

namespace Contacter.Domain.ValueObjects
{
    public class Socials : ValueObject
    {
        private const int MaxLength = 50;
        public string? EmailAddress { get; private set; }
        public string? Twitter { get; private set; }
        public string? Instagram { get; private set; }
        public string? LinkedIn { get; private set; }

        public Socials(string? emailAddress, string? twitter, string? instagram, string? linkedIn)
        {
            if (!string.IsNullOrWhiteSpace(emailAddress) && emailAddress.Length > MaxLength)
            {
                throw new ContactorException("SocialsValidationError", $"Email cannot have more that {MaxLength} characters", nameof(emailAddress));
            }

            if (!string.IsNullOrWhiteSpace(twitter) && twitter.Length > MaxLength)
            {
                throw new ContactorException("SocialsValidationError", $"Url cannot have more that {MaxLength} characters", nameof(twitter));
            }

            if (!string.IsNullOrWhiteSpace(instagram) && instagram.Length > MaxLength)
            {
                throw new ContactorException("SocialsValidationError", $"Url cannot have more that {MaxLength} characters", nameof(instagram));
            }

            if (!string.IsNullOrWhiteSpace(linkedIn) && linkedIn.Length > MaxLength)
            {
                throw new ContactorException("SocialsValidationError", $"Url cannot have more that {MaxLength} characters", nameof(linkedIn));
            }

            EmailAddress = emailAddress;
            Twitter = twitter;
            Instagram = instagram;
            LinkedIn = linkedIn;
        }

        public Socials() {}

        protected override IEnumerable<object?> GetProperties()
        {
            yield return EmailAddress;
            yield return Twitter;
            yield return Instagram;
            yield return LinkedIn;
        }
    }
}
