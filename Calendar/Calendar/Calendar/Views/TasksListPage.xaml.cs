using Calendar.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Calendar.Views
{
	public partial class TasksListPage : ContentPage
	{
        public TasksListViewModel ViewModel { get; private set; }
        
        //public TasksListPage (TasksListViewModel vm)
        public TasksListPage(ObservableCollection<TaskViewModel> tasks)
        {
			InitializeComponent ();
            ViewModel = new TasksListViewModel(tasks);
            //ViewModel = vm;
            ViewModel.Navigation = this.Navigation;
            BindingContext = ViewModel;
        }
	}
}