using Microsoft.EntityFrameworkCore;
using Repositary.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryEF
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
