using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestManagerApp.Models;
using TestManagerApp.Services;
using TestManagerApp.Views.TasksViews;

namespace TestManagerApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TestTask> Tabs { get; } = new();

        private TestTask? _selectedTab;
        public TestTask? SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                _selectedTab = value;
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        public ICommand OpenTaskCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            OpenTaskCommand = new RelayCommand(OpenTask);
        }

        private void OpenTask()
        {
            TestTask teskTab = new TestTask
            {
                Title = "Задание №1",
                Description = "Описание задания №1",
                TaskContent = new FirstTaskTest()
            };

            Tabs.Add(teskTab);
            SelectedTab = teskTab;
            MessageBox.Show("OpenTask work!");
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
