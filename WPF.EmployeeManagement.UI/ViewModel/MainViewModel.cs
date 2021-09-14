using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    
    
    public class MainViewModel


    {
        public MainViewModel(INavigationViewModel navigationViewModel,
            IEmployeeDetailViewModel employeeDetailViewModel,
            IMeetingDetailViewModel meetingDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            EmployeeDetailViewModel = employeeDetailViewModel;
            MeetingDetailViewModel = meetingDetailViewModel;
        }

        public async Task Load()
        {
            //Loads the employee entities into the NavigationView
            await NavigationViewModel.LoadEmployees();
            await NavigationViewModel.LoadMeetings();

        }

        public INavigationViewModel NavigationViewModel { get; }
        public IEmployeeDetailViewModel EmployeeDetailViewModel { get; }
        public IMeetingDetailViewModel MeetingDetailViewModel { get; }

    }
}


//public ObservableCollection<Employee> Employees { get; private set; }

//Private Fields
//private readonly IEmployeeDataService _employeeDataService;
//private Employee _selectedEmployee;

//Event
//public event PropertyChangedEventHandler PropertyChanged;

//Private Fields

//public async Task Load()
//{
//    var employees = await _employeeDataService.GetEmployees();
//    Employees.Clear();
//    foreach (var employee in employees)
//    {
//        Employees.Add(employee);
//    }
//}

//Member Name of the "Caller" is SelectedFriend
//public Employee SelectedEmployee
//{
//    get { return _selectedEmployee; }
//    //When the _selectedFriend Property is set; 
//    //we need to notify the data binding that 
//    //it has changed, IMP! we need to raise a 
//    //propertyChanged event in the "setter"
//    set
//    {
//        _selectedEmployee = value;
//        //This method exists in the ViewModelBase class
//        WhenPropertyChanges(nameof(SelectedEmployee));
//    }
//}

//private void WhenPropertyChanges(string propertyName)
//{
//    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//}