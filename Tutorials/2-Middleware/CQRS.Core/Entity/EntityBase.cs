using System;

namespace CQRS.Core.Entity
{
    public abstract class EntityBase<TId> : IEntityBase<TId> where TId : IEquatable<TId>
    {
        public virtual TId Id { get; set; }
    }
}
