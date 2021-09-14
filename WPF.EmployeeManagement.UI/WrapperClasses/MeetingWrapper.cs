using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.ViewModel;

namespace WPF.EmployeeManagement.UI.WrapperClasses
{
    public class MeetingWrapper : ViewModelPropertyChangedNotifier
    {
        public Meeting Model { get; }
        public MeetingWrapper(Meeting model)
        {
            Model = model;
        }

        public int Id { get { return Model.MeetingID; } }

        private int _title;

        public int Title
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }



    }
}
