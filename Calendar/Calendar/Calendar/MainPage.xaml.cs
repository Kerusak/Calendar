using Xamarin.Forms;
using Calendar.Views;
using Calendar.ViewModels;
using Calendar.Models;
using System.Collections.ObjectModel;

namespace Calendar
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel mvm = new MainPageViewModel(); 
        public MainPage()
        {
            InitializeComponent();

        }

        private async void Calendar_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            lbl.Text = calendar.SelectedDate.Value.ToShortDateString();
            bool datePresent = false;
            CalendarList calendarList = null;
            
            foreach (CalendarList cl in mvm.CalendarLists)
            {
                if (cl.Date == calendar.SelectedDate.Value)
                {
                    datePresent = true;
                    calendarList = cl;
                    break;
                   
                }
            }
            if (!datePresent)
            {
                calendarList = new CalendarList { Date = calendar.SelectedDate.Value, Tasks = new ObservableCollection<TaskViewModel>() };
                mvm.CalendarLists.Add(calendarList);
            }
            await Navigation.PushAsync(new TasksListPage(calendarList.Tasks));
            //await Navigation.PushAsync(new TasksListPage(calendar.SelectedDate.Value));
        }
    }
}
