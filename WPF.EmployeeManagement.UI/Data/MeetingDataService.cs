using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.DataAccess;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public class MeetingDataService : IMeetingDataService
    {
        private readonly Func<EmployeeDbContext> _dbContext;

        public MeetingDataService(Func<EmployeeDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Meeting>> GetMeetings()
        {
            using (var context = _dbContext())
            {
                return await context.Meetings.ToListAsync();
            }
        }

        public async Task<Meeting> GetMeetingById(int meetingMeetingID)
        {
            using (var context = _dbContext())
            {
                return await context.Meetings.SingleAsync(m => m.MeetingID == meetingMeetingID);
            }
        }

        public async Task SaveAsync(Meeting meeting)
        {
            using (var context = _dbContext())
            {
                //Attach Entity to Context so it is aware of the instance
                context.Meetings.Attach(meeting);
                //Context is aware of the Entity's existence but remains unmodified
                context.Entry(meeting).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
