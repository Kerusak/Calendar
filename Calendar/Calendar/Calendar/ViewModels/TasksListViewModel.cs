using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Calendar.Views;
using System;

namespace Calendar.ViewModels
{
    public class TasksListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateTaskCommand { protected set; get; }
        public ICommand DeleteTaskCommand { protected set; get; }
        public ICommand SaveTaskCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        TaskViewModel selectedTask;

        public INavigation Navigation { get; set; }

        public TasksListViewModel(ObservableCollection<TaskViewModel> tasks)
        {
            //Tasks = new ObservableCollection<TaskViewModel>();
            Tasks = tasks;
            CreateTaskCommand = new Command(CreateTask);
            DeleteTaskCommand = new Command(DeleteTask);
            SaveTaskCommand = new Command(SaveTask);
            BackCommand = new Command(Back);
        }

        public TaskViewModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    TaskViewModel tempTask = value;
                    selectedTask = null;
                    OnPropertyChanged("SelectedTask");
                    Navigation.PushAsync(new TaskPage(tempTask));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateTask()
        {
            //
            Navigation.PushAsync(new TaskPage(new TaskViewModel() { ListViewModel = this }));
        }

        private void SaveTask(object obj)
        {
            try
            {
                TaskViewModel task = obj as TaskViewModel;
                if (task != null && task.IsValid)
                {
                    Tasks.Add(task);
                }
                Back();
            }
            catch (Exception)
            {
                Back();
            }
            
        }

        private void DeleteTask(object obj)
        {
            TaskViewModel task = obj as TaskViewModel;
            if (task != null && task.IsValid)
            {
                Tasks.Remove(task);
            }
            Back();
        } 

        private void Back()
        {
            Navigation.PopAsync();
        }
    }
}
