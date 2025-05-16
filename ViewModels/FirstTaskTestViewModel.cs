using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestManagerApp.Services;

namespace TestManagerApp.ViewModels
{
    public class FirstTaskTestViewModel : INotifyPropertyChanged
    {
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
            _testProperty = "Тестовое задание №1";
            TestButtonCommand = new RelayCommand(TestMethod);
        }

        private void TestMethod()
        {
            TestProperty = "Привязка во ViewMolel работает";
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
