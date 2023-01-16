namespace ContactHub.Domain.SeedWork
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; private set; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public bool Equals(Entity? other)
        {
            if (other == null)
            {
                return false;
            }

            // two entites with the same type but different Id are not considered equal
            if (other.GetType() != GetType())
            {
                return false;
            }

            return Id == other.Id;
        }
    }
}
