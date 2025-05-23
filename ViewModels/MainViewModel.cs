using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

        private string? _comboBoxText;
        public string? ComboBoxText
        {
            get => _selectedTab == null ? "Выберите или введите название задания" : _selectedTab.Title;

            set
            {
                _comboBoxText = value;
                OnPropertyChanged(nameof(ComboBoxText));
            }
        }

        public ICommand OpenTaskCommand { get; }
        public ICommand OpenTasksFile { get; }
        public ICommand NewTask { get; }
        public ICommand SaveTasksFile { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            OpenTaskCommand = new RelayCommand(OpenTask);
            OpenTasksFile = new RelayCommand(OpenFile);
            NewTask = new RelayCommand(CreateNewTask);
            SaveTasksFile = new RelayCommand(SaveTasks);
        }

        private void SaveTasks()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранить файл",

            };
        }

        private void CreateNewTask()
        {
            MessageBox.Show("Задание создано");
        }

        private void OpenFile()
        {
            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks_files");

            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Json файлы (*.json)|*.json|Все файлы (*.*) | *.*",
                Title = "Открыть файл",
                InitialDirectory = dataPath
            };

            if (openDialog.ShowDialog() == true)
            {
                MessageBox.Show("Файл открыт");
            }
            
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
