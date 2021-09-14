using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.Model.Model
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //Collection
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
