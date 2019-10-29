using System;

namespace AdvAnalyzer.Domain.Entities
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }

        protected AggregateRoot() : base()
        {
        }
    }
}
