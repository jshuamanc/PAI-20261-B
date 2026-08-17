using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EjemploMVVM.Commands
{
    public class RelayCommand : ICommand
    {
        private Action _execute;

        public RelayCommand(Action funcion)
        {
            this._execute = funcion;
        }

        public event EventHandler? CanExecuteChanged;

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
