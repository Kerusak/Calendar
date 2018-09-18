using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Calendar.Models;
using Calendar.Views;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class MainPageViewModel
    {
        public CalendarList SelectedDate { set; get; }

        public ObservableCollection<CalendarList> CalendarLists { set; get; }

        public ICommand OpenTaskCommand { protected set; get; }

        public MainPageViewModel()
        {
            CalendarLists = new ObservableCollection<CalendarList>();
            OpenTaskCommand = new Command(OpenList);
        }

        public INavigation Navigation { get; set; }
        private void OpenList()
        {
            bool datePresent = false;
            CalendarList calendarList = null;
            foreach (CalendarList cl in CalendarLists)
            {
                if (cl.Date == SelectedDate.Date)
                {
                    datePresent = true;
                    calendarList = cl;
                    break;
                }
            }
            if (!datePresent)
            {
                calendarList = new CalendarList { Date = SelectedDate.Date, Tasks = new ObservableCollection<TaskViewModel>() };
                CalendarLists.Add(calendarList);
            }
            Navigation.PushAsync(new TasksListPage(calendarList.Tasks));

        }
    }

    
}
