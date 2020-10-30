using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
