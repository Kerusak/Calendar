using Calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calendar.Models
{
    public class CalendarList
    {
        public ObservableCollection<TaskViewModel> Tasks { get; set; } = new ObservableCollection<TaskViewModel>();

        public DateTime Date { set; get; }


    }
}
