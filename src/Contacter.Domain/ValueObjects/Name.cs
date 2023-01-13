using Contacter.Domain.Exceptions;
using Contacter.Domain.SeedWork;

namespace Contacter.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        private const int MaxLength = 50;
        public string First { get; private set; }
        public string Last { get; private set; }

        public Name(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first) || first.Length > MaxLength)
            {
                throw new ContactorException("NameValidationError", $"Name cannot be emtpy or have more that {MaxLength} characters", nameof(first));
            }

            if (string.IsNullOrWhiteSpace(last) || last.Length > MaxLength)
            {
                throw new ContactorException("NameValidationError", $"Name cannot be empty or have more that {MaxLength} characters", nameof(last));
            }

            First = first;
            Last = last;
        }

        protected override IEnumerable<object> GetProperties()
        {
            yield return First;
            yield return Last;
        }

        public override string ToString() 
        { 
            return $"{First} {Last}";
        }
    }
}
