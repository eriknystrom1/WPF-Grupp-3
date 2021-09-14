using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;
using WPF.EmployeeManagement.UI.Model;
using WPF.EmployeeManagement.UI.WrapperClasses;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class NavigationViewModel : ViewModelPropertyChangedNotifier, INavigationViewModel
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IMeetingDataService _meetingDataService;

        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Employees { get; }
        public ObservableCollection<NavigationItemViewModel> Meetings { get; }


        public NavigationViewModel(IEmployeeDataService employeeDataService, IMeetingDataService meetingDataService, IEventAggregator eventAggregator)
        {
            _employeeDataService = employeeDataService;
            _meetingDataService = meetingDataService;

            _eventAggregator = eventAggregator;
            Employees = new ObservableCollection<NavigationItemViewModel>();
            Meetings = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterSavedEvent>().Subscribe(AfterSavedEventHandler);
        }

        private void AfterSavedEventHandler(InfoAboutChangedEntityArgs obj)
        {
            var item = Employees.FirstOrDefault(e => e.Id == obj.Id);
            var itemsIndex = Employees.IndexOf(item);
            Employees[itemsIndex].DisplayMember = obj.Firstname;

            var item1 = Meetings.FirstOrDefault(m => m.MeetingID == obj.Id);
            var itemsIndex1 = Meetings.IndexOf(item);
            Meetings[itemsIndex].DisplayMember = obj.Title;



        }



        public async Task LoadEmployees()
        {
            //Returnerar alla employees (Model);
            var employees = await _employeeDataService.GetEmployees();
            Employees.Clear();
            foreach (var employee in employees)
            {
                Debug.WriteLine(employee.Firstname);
                Employees.Add(new NavigationItemViewModel(employee.Id, employee.Firstname));
            }
        }

        public async Task LoadMeetings()
        {
            //Returnerar alla meetings (Model);
            var meetings = await _meetingDataService.GetMeetings();
            Employees.Clear();
            foreach (var meeting in meetings)
            {
                Debug.WriteLine(meeting.Title);
                Meetings.Add(new NavigationItemViewModel(meeting.MeetingID, meeting.Title));
            }
        }

        private NavigationItemViewModel _selectedEmployee;
        private NavigationItemViewModel _selectedMeeting;


        public NavigationItemViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;

                OnPropertyChanged(nameof(SelectedEmployee));
                Debug.WriteLine("PUBLISHER " + _selectedEmployee.Id);
                Debug.WriteLine("PUBLISHER " + _selectedEmployee.DisplayMember);
                _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedEmployee.Id);
            }
        }

             public NavigationItemViewModel SelectedMeeting
        {
            get { return _selectedMeeting; }
            set
            {
                _selectedMeeting = value;

                OnPropertyChanged(nameof(SelectedMeeting));
                Debug.WriteLine("PUBLISHER " + _selectedMeeting.Id);
                Debug.WriteLine("PUBLISHER " + _selectedMeeting.DisplayMember);
                _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedMeeting.Id);
            }
        }





    }
}
