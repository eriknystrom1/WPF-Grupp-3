using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public interface IEmployeeDataService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task SaveAsync(Employee employee);
    }
}
