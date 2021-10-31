using System;

namespace MVCApi.Domain.Entites
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }

        protected BaseEntity(Guid id)
        {
            Id = id;
            DateCreated = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime DateCreated { get; protected set; }
    }
}