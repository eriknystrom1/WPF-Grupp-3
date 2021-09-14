using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public interface IMeetingDetailViewModel
    {
        Task LoadMeetingById(int meetingMeetingID);
    }
}
