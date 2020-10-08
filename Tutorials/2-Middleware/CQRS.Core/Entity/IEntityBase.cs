using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Core.Entity
{
    public interface IEntityBase<TId> where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
