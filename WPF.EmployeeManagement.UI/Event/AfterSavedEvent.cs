using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.Event
{
    public class AfterSavedEvent : PubSubEvent<InfoAboutChangedEntityArgs>
    {

    }

    public class InfoAboutChangedEntityArgs
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Title { get; set; }
    }
}
