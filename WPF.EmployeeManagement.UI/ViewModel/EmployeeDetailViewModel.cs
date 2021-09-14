using Prism.Commands;
using Prism.Events;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class EmployeeDetailViewModel : ViewModelPropertyChangedNotifier, IEmployeeDetailViewModel
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IEventAggregator _eventAggregator;

        public EmployeeDetailViewModel(IEmployeeDataService employeeDataService, IEventAggregator eventAggregator)
        {
            _employeeDataService = employeeDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Subscribe(HandleEmployeeSelectedEvent);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _employeeDataService.SaveAsync(Employee);
            // Notify NavigationViewModel of changes in DB
            _eventAggregator.GetEvent<AfterSavedEvent>().Publish(
                new InfoAboutChangedEntityArgs
                {
                    Id = Employee.Id,
                    Firstname = Employee.Firstname
                });
        }

        private async void HandleEmployeeSelectedEvent(int employeeId)
        {
            Debug.WriteLine("SUBSCRIBER " + employeeId);
            await LoadEmployeeById(employeeId);
        }

        public async Task LoadEmployeeById(int employeeId)
        {
            Employee = await _employeeDataService.GetEmployeeById(employeeId);


        }

        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

        public ICommand SaveCommand { get; }
    }
}
