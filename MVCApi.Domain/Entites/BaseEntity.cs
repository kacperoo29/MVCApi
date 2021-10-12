using System;

namespace MVCApi.Domain.Entites
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}
