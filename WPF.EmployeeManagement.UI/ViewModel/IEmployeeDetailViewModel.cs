using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public interface IEmployeeDetailViewModel
    {
        Task LoadEmployeeById(int employeeId);
    }
}