using Xamarin.Forms;
using Calendar.ViewModels;

namespace Calendar.Views
{
	public partial class TaskPage : ContentPage
	{
        public TaskViewModel ViewModel { get; private set; }
        public TaskPage(TaskViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}