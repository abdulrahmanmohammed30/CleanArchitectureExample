using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Application.Common.interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
