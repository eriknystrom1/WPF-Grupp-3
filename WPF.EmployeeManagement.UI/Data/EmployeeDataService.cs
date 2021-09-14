using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.DataAccess;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly Func<EmployeeDbContext> _dbContext;

        public EmployeeDataService(Func<EmployeeDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            using (var context = _dbContext())
            {
                return  await context.Employees.ToListAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            using(var context = _dbContext())
            {
                return await context.Employees.SingleAsync(e => e.Id == employeeId);
            }
        }

        public async Task SaveAsync(Employee employee)
        {
            using(var context = _dbContext())
            {
                //Attach Entity to Context so it is aware of the instance
                context.Employees.Attach(employee);
                //Context is aware of the Entity's existence but remains unmodified
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
