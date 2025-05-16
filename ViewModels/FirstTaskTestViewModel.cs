using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestManagerApp.Models;
using TestManagerApp.Services;

namespace TestManagerApp.ViewModels
{
    public class FirstTaskTestViewModel : INotifyPropertyChanged
    {
        private TestAssignment _testAssignment;
        private static int _assignmentCounter = 1;

        public Dictionary<string, string> AssignmentProperties
        {
            get
            {
                return UsingProperties(_testAssignment);

            }
            set
            {
                AssignmentProperties = value;
                OnPropertyChanged(nameof(AssignmentProperties));
            }

        }

        private string? _testProperty;
        public string? TestProperty
        {
            get { return _testProperty; }
            set
            {
                _testProperty = value;
                OnPropertyChanged(nameof(TestProperty));
            }
        }

        public ICommand TestButtonCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public FirstTaskTestViewModel()
        {
            
            _testAssignment = new TestAssignment()
            {
                Number = _assignmentCounter++,
                Id = Guid.NewGuid(),
                DateTimeAdded = DateTime.Now,
                Description = "Описание",
                IsCompleted = false,
                ProjectPath = "C:/anything"
            };
            _testProperty = "Тестовое задание №1";
            TestButtonCommand = new RelayCommand(TestMethod);
        }

        public Dictionary<string, string> UsingProperties(TestAssignment assignment)
        {
            return new Dictionary<string, string>
            {
                ["Number"] = assignment.Number.ToString(),
                ["Id"] = assignment.Id.ToString(),
                ["Description"] = assignment.Description.ToString(),
                ["ProjectPath"] = assignment.ProjectPath,
                ["DateTimeAdded"] = assignment.DateTimeAdded.ToString(),
                ["IsCompleted"] = assignment.IsCompleted ? "Да" : "Нет"

            };
        }

        private void TestMethod()
        {
            TestProperty = "Привязка во ViewModel работает";
            OnPropertyChanged(TestProperty);
        }

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            return;
        }
    }
}
