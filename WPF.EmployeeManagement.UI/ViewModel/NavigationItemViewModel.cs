using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelPropertyChangedNotifier
    {
        public NavigationItemViewModel(int entityId, string entityDisplayMember)
        {
            Id = entityId;
            DisplayMember = entityDisplayMember;
        }

        public int Id { get; }
        public int MeetingID { get; }


        private string _displayMember;

        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value;
                OnPropertyChanged(nameof(DisplayMember));
            }
        }

    }
}
