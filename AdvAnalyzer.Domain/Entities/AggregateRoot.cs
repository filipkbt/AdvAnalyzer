using System;
using System.Collections.Generic;
using System.Text;

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
