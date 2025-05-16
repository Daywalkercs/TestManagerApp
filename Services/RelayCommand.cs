using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestManagerApp.Services
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Func<bool>? _canExecute;
        private readonly Action _execute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
            
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
