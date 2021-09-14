using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public interface INavigationViewModel
    {
        Task LoadEmployees();
        Task LoadMeetings();

    }
}