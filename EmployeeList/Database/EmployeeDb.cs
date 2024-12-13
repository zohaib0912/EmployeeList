using EmployeeList.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeList.Database
{
    public class EmployeeDb : DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
    }
}
