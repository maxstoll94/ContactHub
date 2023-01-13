using Contacter.Domain.SeedWork;

namespace Contacter.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string First { get; private set; }
        public string Last { get; private set; }

        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        protected override IEnumerable<object> GetEqualityComponents()
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
