using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Model;
using WPF.EmployeeManagement.UI.ViewModel;

namespace WPF.EmployeeManagement.UI.WrapperClasses
{
    public class EmployeeWrapper : ViewModelPropertyChangedNotifier
    {
        public Employee Model { get; }
        public EmployeeWrapper(Employee model)
        {
            Model = model;
        }

        public int Id { get { return Model.Id; } }
        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set { 
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
                
            }
        }

        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private Department _department;

        public Department Department
        {
            get { return _department; }
            set { _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        private int _phonenumber;

        public int Phonenumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value;
                OnPropertyChanged(nameof(Phonenumber));
            }
        }
    }
}
