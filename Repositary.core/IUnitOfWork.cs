using Repositary.core.interfaces;
using Repositary.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.core
{
    public interface IUnitOfWork :IDisposable
    {
        iBaseRepository<Department> Departments { get; }
        iBaseRepository<Employee> Employees { get; }


        int Complete();

    }
}
