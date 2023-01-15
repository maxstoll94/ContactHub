using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHub.Domain.SeedWork
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object?> GetProperties();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetProperties().SequenceEqual(other.GetProperties());
        }

        public override int GetHashCode()
        {
            return GetProperties()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
        }
    }
}
