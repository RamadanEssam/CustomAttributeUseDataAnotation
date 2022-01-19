using Repositary.core;
using Repositary.core.interfaces;
using Repositary.core.Models;
using RepositaryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryEF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public iBaseRepository<Department > Departments { get; private set; }
        public iBaseRepository<Employee> Employees { get; private set; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Departments = new BaseRepository<Department>(_context);
            Employees = new BaseRepository<Employee>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
