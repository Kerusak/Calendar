using System;
using System.ComponentModel;
using Calendar.Models;

namespace Calendar.ViewModels
{
    [Serializable]
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        TasksListViewModel lvm;

        public MyTask MyTask { get; private set; }

        public TaskViewModel()
        {
            MyTask = new MyTask();
        }

        public TasksListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Title
        {
            get { return MyTask.Title; }
            set
            {
                if (MyTask.Title != value)
                {
                    MyTask.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Desc
        {
            get { return MyTask.Desc; }
            set
            {
                if (MyTask.Desc != value)
                {
                    MyTask.Desc = value;
                    OnPropertyChanged("Desc");
                }
            }
        }
        public string TimeToGoal
        {
            get { return MyTask.TimeToGoal; }
            set
            {
                if (MyTask.TimeToGoal != value)
                {
                    MyTask.TimeToGoal = value;
                    OnPropertyChanged("TimeToGoal");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Title.Trim())) ||
                    (!string.IsNullOrEmpty(Desc.Trim())) ||
                    (!string.IsNullOrEmpty(TimeToGoal.Trim())));
            }
        }


        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
