using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.Model.Model
{
    public class Employee_Meeting
    {
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }


        public int MeetingID { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}
