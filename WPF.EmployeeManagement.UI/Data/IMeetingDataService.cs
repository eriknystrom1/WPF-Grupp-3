using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public interface IMeetingDataService
    {
        Task<List<Meeting>> GetMeetings();
        Task<Meeting> GetMeetingById(int meetingMeetingID);
        Task SaveAsync(Meeting meeting);
    }
}
