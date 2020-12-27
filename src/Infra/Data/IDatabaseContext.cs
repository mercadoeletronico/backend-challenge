using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infra.Data
{
    public interface IDatabaseContext
    {
        IDbConnection Connection { get; }

    }
}
