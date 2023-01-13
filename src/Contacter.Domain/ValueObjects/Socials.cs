
using Contacter.Domain.SeedWork;

namespace Contacter.Domain.ValueObjects
{
    public class Socials : ValueObject
    {
        public string? EmailAddress { get; private set; }
        public string? Twitter { get; private set; }
        public string? Instagram { get; private set; }
        public string? LinkedIn { get; private set; }

        public Socials(string? emailAddress, string? twitter, string? instagram, string? linkedIn)
        {
            EmailAddress = emailAddress;
            Twitter = twitter;
            Instagram = instagram;
            LinkedIn = linkedIn;
        }

        public Socials() {}

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return EmailAddress;
            yield return Twitter;
            yield return Instagram;
            yield return LinkedIn;
        }
    }
}
