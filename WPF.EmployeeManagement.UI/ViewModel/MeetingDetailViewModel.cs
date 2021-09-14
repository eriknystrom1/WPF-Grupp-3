using Prism.Commands;
using Prism.Events;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class MeetingDetailViewModel : ViewModelPropertyChangedNotifier, IMeetingDetailViewModel
    {
        private readonly IMeetingDataService _meetingDataService;
        private readonly IEventAggregator _eventAggregator;

        public MeetingDetailViewModel(IMeetingDataService meetingDataService, IEventAggregator eventAggregator)
        {
            _meetingDataService = meetingDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Subscribe(HandleMeetingSelectedEvent);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _meetingDataService.SaveAsync(Meeting);
            // Notify NavigationViewModel of changes in DB
            _eventAggregator.GetEvent<AfterSavedEvent>().Publish(
                new InfoAboutChangedEntityArgs
                {
                    Id = Meeting.MeetingID,
                    Title = Meeting.Title
                });
        }

        private async void HandleMeetingSelectedEvent(int meetingMeetingID)
        {
            Debug.WriteLine("SUBSCRIBER " + meetingMeetingID);
            await LoadMeetingById(meetingMeetingID);
        }

        public async Task LoadMeetingById(int meetingMeetingID)
        {
            Meeting = await _meetingDataService.GetMeetingById(meetingMeetingID);


        }

        private Meeting _meeting;

        public Meeting Meeting
        {
            get { return _meeting; }
            set
            {
                _meeting = value;
                OnPropertyChanged(nameof(Meeting));
            }
        }

        public ICommand SaveCommand { get; }
    }
}
