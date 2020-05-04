using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public SQLEmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee Add(Employee employee)
        {
            dbContext.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return dbContext.Employees.Find(id);
        }

        public Employee Update(Employee employee)
        {
            var emp = dbContext.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return employee;
        }
    }
}
