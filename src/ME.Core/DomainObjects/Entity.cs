using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Core.DomainObjects
{
    public abstract class Entity
    {
        public override string ToString()
        {
            return $"{GetType().Name}";
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

    }
}
