using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common.Domain
{
    public interface IEntity<T>
    {
        T id { get; }
    }
}
